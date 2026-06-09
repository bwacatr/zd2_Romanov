using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zd2_Romanov
{
    static class PhoneBookLoader
    {
        public static void Load(PhoneBook phoneBook, string fileName) // загрузка книжки с помощью файла
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    while (!sr.EndOfStream) 
                    {
                        string text = sr.ReadLine();
                        string[] array = text.Split(';');

                        Contact contact = new Contact();
                        contact.Name = array[0];
                        contact.Phone = array[1];

                        phoneBook.contacts.Add(contact);
                    }

                }

            }

        }

        public static void Save(PhoneBook phoneBook, string fileName) // Сохранение книжки в файл
        {

            using (StreamWriter sw = File.CreateText(fileName))
            {
                foreach (var item in phoneBook.contacts)
                {
                    sw.WriteLine($"{item.Name};{item.Phone}");
                }



            }

        }
    }
}
