using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_Romanov
{
    class PhoneBook
    {
        public List<Contact> contacts = new List<Contact>();

        

        public List<Contact> SearchByName(string name) // Поиск по имени и выдача списка с подходящими контактами
        {
            List<Contact> list = new List<Contact>();
            var search = from contact in contacts where contact.Name == name select contact;

            foreach (var item in search)
            {
                list.Add(item);
            }

            return list;
        }

        public void AddContact(Contact contact) // добавление контакта в список
        {
            contacts.Add(contact);
        }

        public void AddContact(string name, string phone) // создание и добавление контакта в список 
        {
            var count = from contact in contacts where contact.Phone == phone select contact;
            if (count.Count() == 0)
            {
                Contact contact = new Contact { Name = name, Phone = phone };
                AddContact(contact);
            }
        }

        public void DeleteContact(Contact contact) // удаление контакта из списка
        {
            contacts.Remove(contact);
        }

        public void DeleteContact(int index) // удаление контакта
        {
            contacts.RemoveAt(index);
        }
    }
}
