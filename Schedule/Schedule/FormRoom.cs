﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class FormRoom : Form
    {
        public FormRoom()
        {
            InitializeComponent();
        }

        public static bool editObj(Room obj)
        {
            FormRoom fm = new FormRoom();
            fm.textName.Text = obj.RoomN;
            fm.textCount.Text = obj.Count.ToString("D");
            fm.clbSoft.Items.Clear();
            foreach (var item in Time.getAllPairs())
                fm.clbSoft.Items.Add(item, obj.isPairSoftDeny(item));
            fm.clbHard.Items.Clear();
            foreach (var item in Time.getAllPairs())
                fm.clbHard.Items.Add(item, obj.isPairHardDeny(item));

            if (fm.ShowDialog() == DialogResult.OK)
            {
                obj.RoomN = fm.textName.Text.Trim();
                obj.Count = Int32.Parse(fm.textCount.Text.Trim());
                obj.softlimits.Clear();
                foreach (var item in fm.clbSoft.CheckedItems)
                    obj.softlimits.Add((Time)item);
                obj.hardlimits.Clear();
                foreach (var item in fm.clbHard.CheckedItems)
                    obj.hardlimits.Add((Time)item);

                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
