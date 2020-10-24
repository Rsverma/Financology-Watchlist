using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financology.Watchlist
{
    public partial class WatchlistForm : SfForm
    {
        private GridTab mainTabData;
        public WatchlistForm()
        {
            InitializeComponent();
            mainTabData = new GridTab();
            dataGrid = mainTabData._grid;
            this.mainTab.Controls.Add(this.dataGrid);
        }

        private void addSymbolbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(symbolTextBox.Text))
                MessageBox.Show("Please enter a valid symbol");
            else
            {
                DataManager.instance.AddSymbol(symbolTextBox.Text);
                symbolTextBox.Text = string.Empty;
            }
        }
    }
}
