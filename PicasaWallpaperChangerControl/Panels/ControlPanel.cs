using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public delegate void EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result);
    
    public class ControlPanel : UserControl
    {
        public AvailablePanels mCurrentPanel;
        public ControlPanel()
        {
        }
        public ControlPanel(AvailablePanels panel)
        {
            this.mCurrentPanel = panel;
        }
        public AvailablePanels PanelType
        {
            get
            {
                return this.mCurrentPanel;
            }
        }

        public virtual event EventFired ev_EventFired;
    }
}
