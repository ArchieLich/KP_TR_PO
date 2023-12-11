using Library.Infrastructure.Mappers;
using Library.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using Library.Infrastructure.Database;

namespace Library.Infrastructure.Database
{
    public class RoleRepository
    {
        public List<RoleViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.client.ToList();
                return RoleMapper.Map(items);
            }
        }

        public RoleViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.client.FirstOrDefault(x => x.id == id);
                return RoleMapper.Map(item);
            }
        }

        public RoleViewModel Update(RoleViewModel entity) // метод редактирования существующей записи клиента в бд
        {
            entity.fio = entity.fio.Trim();
            if (string.IsNullOrEmpty(entity.fio))
                MessageBox.Show("Имя Пользователя не может быть пустым");

            using (var context = new Context())
            {
                var item = context.client.FirstOrDefault(x => x.id == entity.id);
                if (item != null)
                {
                    item.fio = entity.fio;
                    context.SaveChanges();
                }
                else
                {
                    System.Windows.MessageBox.Show("");
                    MessageBox.Show("Ничего не было сохранено");
                }
                return RoleMapper.Map(item);
            }
        }

        public RoleViewModel Add(RoleViewModel entity) // метод добавления клиента в бд
        {
            entity.fio = entity.fio.Trim();
            if(string.IsNullOrEmpty(entity.fio))
            {
                throw new Exception("Имя Пользователя не может быть пустым");
            }
            using (var context = new Context())
            {
                var item = RoleMapper.Map(entity);
                context.client.Add(item);
                if (item != null)
                {
                    item.fio = entity.fio;
                    context.client.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное Сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return RoleMapper.Map(item);
            }
        }

        public void Delete(long id) // метод удаления существующей записи клиента в бд
        {
            // удаляем клиента
            using (var context = new Context())
            {
                var user = context.client.FirstOrDefault(x => x.id == id);
                if (user != null)
                {
                    context.client.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public List<RoleViewModel> Search(string search) // метод поиска существующей записи клиента в грид
        {
            search = search.Trim();
           using (var context = new Context())
           {
               var result = context.client.Where(x => x.fio.Contains(search) && x.fio.StartsWith(search).ToString().Contains(search)).ToList();
               return RoleMapper.Map(result);
           }
        } 
    }
}
