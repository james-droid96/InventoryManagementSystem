using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CustomerButton : PictureBox //Inheritance
    {
        public CustomerButton() // Constructor implementation
        {
            InitializeComponent();
        }
        private Image NormalImage; 
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }
        public Image ImageHover //Declaring Variables
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }


        //Method declarations
        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            //Popping up the image
            this.Image = HoverImage;
        }

        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        { 
            //Popping Up the image
            this.Image = NormalImage;
        }
    }
}
