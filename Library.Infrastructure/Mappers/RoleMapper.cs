using Library.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Mappers
{
    public static class RoleMapper
    {
        public static RoleViewModel Map(RoleEntity entity)
        {
            var viewModel = new RoleViewModel
            {
                id = entity.id,
                fio = entity.fio,
                
            };
            return viewModel;
        }

        public static List<RoleViewModel> Map(List<RoleEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static RoleEntity Map(RoleViewModel viewModel)
        {
            var entity = new RoleEntity
            {
                id = viewModel.id,
                fio = viewModel.fio,
            };
            return entity;
        }

    }
}
