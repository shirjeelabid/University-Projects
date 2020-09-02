using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.PeerResolvers;

namespace ChatServer
{
    public partial class server : Form
    {
        private CustomPeerResolverService cp;
        private ServiceHost host;
        public server()
        {
            InitializeComponent();
            btnStop.Enabled = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cp = new CustomPeerResolverService();
                cp.RefreshInterval = TimeSpan.FromSeconds(5);
                host = new ServiceHost(cp);
                cp.ControlShape = true;
                cp.Open();




                host.Open(TimeSpan.FromDays(2345545));
                MessageBox.Show("Server is start now");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           try
            {
                cp.Close();
                host.Close();
                MessageBox.Show("Server Stop");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }
    }
}
