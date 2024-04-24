using AutoMapper;
using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Infrastructure.Interfaces;
using KBStarCoreApp.Utilities.Constants;
using System.Collections.Generic;
using System.Linq;

namespace KBStarCoreApp.Application.Implementation
{
    public class CommonService : ICommonService
    {
        private IRepository<Footer, string> _footerRepository;
        private IRepository<SystemConfig, string> _systemConfigRepository;
        private IUnitOfWork _unitOfWork;
        private IRepository<Slide, int> _slideRepository;
        private readonly IMapper _mapper;

        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<SystemConfig, string> systemConfigRepository,
            IUnitOfWork unitOfWork, IMapper mapper,
            IRepository<Slide, int> slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
            _mapper = mapper;
        }

        public FooterViewModel GetFooter()
        {
            return _mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _mapper.ProjectTo<SlideViewModel>(_slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)).ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return _mapper.Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}