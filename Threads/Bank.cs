using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Threads
{
    public class Bank : INotifyPropertyChanged
    {
        private int money;
        private string name;
        private int persent;
        public string property;
        ThreadStart ts = null;
        Thread t1 = null;
        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                OnPropertyChanged("Money");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Percent
        {
            get { return persent; }
            set
            {
                persent = value;
                OnPropertyChanged("Percent");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                ts = new ThreadStart(Save);
                t1 = new Thread(ts);
                t1.Start();
                t1.IsBackground = true;
                property = prop;
            }
        }
        private void Save()
        {
            using (StreamWriter sw = new StreamWriter("banks.txt", false, Encoding.Default))
            {
                sw.WriteLine($"Money - {Money}\r\nName - {Name}\r\nPercent - {Percent}");
            }
            Serializer<Bank>.Save("bank.xml", this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
