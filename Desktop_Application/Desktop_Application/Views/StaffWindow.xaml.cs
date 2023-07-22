using Desktop_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_Application.Views
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
            DataContext = new StaffWindowVM();
        }



        // Helper method to find an ancestor of a given type
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
        }

        // Helper method to find a child element of a given name
        private static T FindChild<T>(DependencyObject parent, string childName) where T : FrameworkElement
        {
            if (parent == null) return null;

            T child = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var childElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (childElement == null) continue;

                if (childElement is T childOfType && childElement.Name == childName)
                {
                    child = childOfType;
                    break;
                }
                else
                {
                    child = FindChild<T>(childElement, childName);
                    if (child != null) break;
                }
            }
            return child;
        }

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            // Find the parent DataGridRow
            var row = FindAncestor<DataGridRow>((Button)sender);

            // Find the TextBlock and TextBox controls within the row
            var textfirstname = FindChild<TextBlock>(row, "textfirstname");
            var txtfirstname = FindChild<TextBox>(row, "txtfirstname");

            var textlastname = FindChild<TextBlock>(row, "textlastname");
            var txtlastname = FindChild<TextBox>(row, "txtlastname");

            var textnic = FindChild<TextBlock>(row, "textnic");
            var txtnic = FindChild<TextBox>(row, "txtnic");

            var editbutton = FindChild<Button>(row, "editbutton");
            var deletebutton = FindChild<Button>(row, "deletebutton");

            var conformeditbutton = FindChild<Button>(row, "conformeditbutton");
            var canceleditbutton = FindChild<Button>(row, "canceleditbutton");

            // Toggle the visibility of the controls
            //textBlock.Visibility = textBlock.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            //textBox.Visibility = textBox.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            textfirstname.Visibility = Visibility.Collapsed;
            txtfirstname.Visibility = Visibility.Visible;

            textlastname.Visibility = Visibility.Collapsed;
            txtlastname.Visibility = Visibility.Visible;

            textnic.Visibility = Visibility.Collapsed;
            txtnic.Visibility = Visibility.Visible;

            //editbutton.Visibility = Visibility.Collapsed;
            //deletebutton.Visibility = Visibility.Collapsed;

            conformeditbutton.Visibility = Visibility.Visible;
            canceleditbutton.Visibility = Visibility.Visible;
        }

        private void canceleditbutton_Click(object sender, RoutedEventArgs e)
        {
            var row = FindAncestor<DataGridRow>((Button)sender);

            // Find the TextBlock and TextBox controls within the row
            var textfirstname = FindChild<TextBlock>(row, "textfirstname");
            var txtfirstname = FindChild<TextBox>(row, "txtfirstname");

            var textlastname = FindChild<TextBlock>(row, "textlastname");
            var txtlastname = FindChild<TextBox>(row, "txtlastname");

            var editbutton = FindChild<Button>(row, "editbutton");
            var deletebutton = FindChild<Button>(row, "deletebutton");

            var conformeditbutton = FindChild<Button>(row, "conformeditbutton");
            var canceleditbutton = FindChild<Button>(row, "canceleditbutton");

            txtfirstname.Visibility = Visibility.Collapsed;
            textfirstname.Visibility = Visibility.Visible;

            txtlastname.Visibility = Visibility.Collapsed;
            textlastname.Visibility = Visibility.Visible;

            conformeditbutton.Visibility = Visibility.Collapsed;
            canceleditbutton.Visibility = Visibility.Collapsed;

            editbutton.Visibility = Visibility.Visible;
            deletebutton.Visibility = Visibility.Visible;

        }

       
    }
}
