using Library.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Mappers
{
    public static class PublicationMapper
    {
        public static PublicationViewModel Map(PublicationEntity entity)
        {
            var viewModel = new PublicationViewModel
            {
                id = entity.id,
                name = entity.name,
                cost = entity.cost,

            };
            return viewModel;
        }

        public static List<PublicationViewModel> Map(List<PublicationEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static PublicationEntity Map(PublicationViewModel viewModel)
        {
            var entity = new PublicationEntity
            {
                id = viewModel.id,
                name = viewModel.name,
                cost = viewModel.cost,
            };
            return entity;
        }
    }
}
