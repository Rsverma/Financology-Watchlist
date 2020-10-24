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
            this.symbolTextBox.KeyDown += SymbolTextBox_KeyDown;
        }

        private void SymbolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addSymbolbutton_Click(this, new EventArgs());
            }
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
