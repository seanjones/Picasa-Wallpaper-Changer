using System;
using System.Collections.Generic;

using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    /// <summary>
    /// This is for managing google account login
    /// </summary>
    public class AccountLogin
    {
        /// <summary>
        /// Call this when creating new account details, it prepares an asym key, and stores it by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="iv">an empty string which will contain the encrypted iv</param>
        /// <param name="key">an empty string which will contain the encrypted key</param>
        /// <returns>The encrypted password</returns>
        public static string AddNewAccount(string username, string password, ref string key, ref string iv)
        {
            // The parameters define the name of the key store, which will hold the password 
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = "PWC" + username;

            // This will be the actual key store
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters);

            // Now Encrypt the password and store the data
            return EncryptPassword(username, password, ref key, ref iv);
        }

        private static string GetKey(string username)
        {
            // The parameters define the name of the key store
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = "PWC"+username;
            

            // This will be the actual key store
            try
            {
                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters);


                return rsaCryptoServiceProvider.ToXmlString(true);
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("Key not valid for use in specified state."))
                {
                    DeleteKeyFromContainer(username);
                    GetKey(username);
                }
                else
                    throw ex;
            }
            return "";
        }

        /// <summary>
        /// This encrypts a plain text password, and return it, along with aysm encrypted key and iv
        /// </summary>
        /// <param name="storeName">The name of the aysm key store</param>
        /// <param name="password">The plain text password</param>
        /// <param name="key">The encrypted key</param>
        /// <param name="IV">The encrypted IV</param>
        /// <returns>The encrpted password</returns>
        public static string EncryptPassword(string storeName, string password, ref string key, ref string IV)
        {
            // retrieve the asym key from storage
            string asymkey = GetKey(storeName);
            string retval = string.Empty;
            // Create values to store encrypted symmetric keys.
            byte[] encryptedSymmetricKey;
            byte[] encryptedSymmetricIV;

            // Create a new instance of the RSACryptoServiceProvider class.
            RSACryptoServiceProvider asymKeyProvider = new RSACryptoServiceProvider();

            // Set RSAKeyInfo to the public key values. 
            asymKeyProvider.FromXmlString(asymkey);

            // Create a new instance of the RijndaelManaged class
            RijndaelManaged encryptionWrapper = new RijndaelManaged();

            // Get a new key and vector
            encryptionWrapper.KeySize = 256;
            encryptionWrapper.GenerateIV();
            encryptionWrapper.GenerateKey();

            // create an encrypter
            ICryptoTransform encryptionTransformer = encryptionWrapper.CreateEncryptor();

            // Create a  streams to hold the encrypted data
            MemoryStream targetMemoryStream = null;
            CryptoStream encryptionStream = null;
            StreamWriter sourceWriterStream = null;
            try
            {
                targetMemoryStream = new MemoryStream();

                // this will do the encrypting
                encryptionStream = new CryptoStream(targetMemoryStream, encryptionTransformer, CryptoStreamMode.Write);

                // this will write the data to the encrypter
                sourceWriterStream = new StreamWriter(encryptionStream);

                // encrypt!
                sourceWriterStream.Write(password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Whoops", ex.Message);
            }
            finally
            {
                if (sourceWriterStream != null)
                    sourceWriterStream.Close();
                if (encryptionStream != null)
                    targetMemoryStream.Close();
                if (targetMemoryStream != null)
                {
                    targetMemoryStream.Close();
                    retval = Convert.ToBase64String(targetMemoryStream.ToArray());
                }
                if (encryptionTransformer != null)
                    encryptionTransformer.Dispose();
            }

            // Encrypt the symmetric key and IV.
            encryptedSymmetricKey = asymKeyProvider.Encrypt(encryptionWrapper.Key, true);
            encryptedSymmetricIV = asymKeyProvider.Encrypt(encryptionWrapper.IV, true);

            // set the return values, and we are done.
            key = Convert.ToBase64String(encryptedSymmetricKey);

            IV = Convert.ToBase64String(encryptedSymmetricIV);

            encryptionWrapper.Clear();
            return Convert.ToBase64String(targetMemoryStream.ToArray());
        }

        /// <summary>
        /// This decrypts an encrpted password, and returns it
        /// </summary>
        /// <param name="storeName">The name of the aysm key store</param>
        /// <param name="password">The plain text password</param>
        /// <param name="key">The encrypted key</param>
        /// <param name="IV">The encrypted IV</param>
        /// <returns>The plain text password</returns>
        public static string DecryptPassword(string storeName, string password, string key, string iv)
        {
            // retrieve the asym key from storage
            string asymkey = GetKey(storeName);
            string retval = string.Empty;

            // get the encrypted and and iv as bytes.
            byte[] encryptedSymmetricKey = Convert.FromBase64String(key);
            byte[] encryptedSymmetricIV = Convert.FromBase64String(iv);

            // Create a new instance of the RijndaelManaged class
            RijndaelManaged decryptionWrapper = new RijndaelManaged();

            // Create a new instance of the RSACryptoServiceProvider class.
            RSACryptoServiceProvider asymKeyProvider = new RSACryptoServiceProvider();

            // Set RSAKeyInfo to the public key values. 
            asymKeyProvider.FromXmlString(asymkey);

            // decrypt the symmetric key and IV.
            decryptionWrapper.Key = asymKeyProvider.Decrypt(encryptedSymmetricKey, true);
            decryptionWrapper.IV = asymKeyProvider.Decrypt(encryptedSymmetricIV, true);

            // create a decrypter
            ICryptoTransform decryptionTransformer = decryptionWrapper.CreateDecryptor();

            // Create a  streams to hold the decrypted data
            MemoryStream sourceMemoryStream = null;
            CryptoStream decryptionStream = null;
            StreamReader targetReaderStream = null;
            try
            {
                sourceMemoryStream = new MemoryStream(Convert.FromBase64String(password));

                // this will do the decrypting
                decryptionStream = new CryptoStream(sourceMemoryStream, decryptionTransformer, CryptoStreamMode.Read);

                // this will write the data to the decrypter
                targetReaderStream = new StreamReader(decryptionStream);

                // decrypt!
                retval = targetReaderStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Whoops", ex.Message);
            }
            finally
            {
                if (targetReaderStream != null)
                    targetReaderStream.Close();
                if (decryptionStream != null)
                    sourceMemoryStream.Close();
                if (sourceMemoryStream != null)
                    sourceMemoryStream.Close();
                if (decryptionTransformer != null)
                    decryptionTransformer.Dispose();
            }
            decryptionWrapper.Clear();
            return retval;

        }


        public static void DeleteKeyFromContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Delete the key entry in the container.
            rsa.PersistKeyInCsp = false;

            // Call Clear to release resources and delete the key from the container.
            rsa.Clear();
        }
    }
}