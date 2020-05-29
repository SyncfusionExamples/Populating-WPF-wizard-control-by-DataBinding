using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wizard_ItemsSource
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<Model> pageitems;
        public ObservableCollection<Model> PageItems
        {
            get
            {
                return pageitems;
            }
            set
            {
                pageitems = value;
                RaisePropertyChanged("PageItems");
            }
        }

        public ViewModel()
        {
            pageitems = new ObservableCollection<Model>();

            PopulatePageItems();
        }

        private void PopulatePageItems()
        {
            pageitems.Add(new Model { Title = "XML Developer's Guide", Content = "An indepth look at creating applications with XML."});
            pageitems.Add(new Model { Title = "Midnight Rain", Content = "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."});
            pageitems.Add(new Model { Title = "Oberon's Legacy", Content = "In postapocalypse England, the mysterious agent known only as Oberon helps to create a new life for the inhabitants of London. Sequel to Maeve Ascendant."});
            pageitems.Add(new Model { Title = "Lover Birds", Content = "When Carla meets Paul at an ornithology conference, tempers fly as feathers get ruffled."});
            pageitems.Add(new Model { Title = "Science Fiction", Content = "After an inadvertant trip through a Heisenberg Uncertainty Device, James Salway discovers the problems of being quantum."});
        }
    }

    public class Model : NotificationObject
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                RaisePropertyChanged("Description");
            }
        }     
    }
}
