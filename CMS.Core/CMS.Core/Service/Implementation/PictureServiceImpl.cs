using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Exceptions;
using CMS.Core.Makers.Interface;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CMS.Core.Service.Implementation
{
    public class PictureServiceImpl : PictureService
    {
        private readonly PictureRepository _pictureRepository;
        private readonly PictureMaker _pictureMaker;
        public PictureServiceImpl(PictureRepository pictureRepository, PictureMaker pictureMaker)
        {
            _pictureRepository = pictureRepository;
            _pictureMaker = pictureMaker;

        }
        public void delete(long picture_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var picture = _pictureRepository.getById(picture_id);
                    if (picture == null)
                    {
                        throw new ItemNotFoundException($" {picture_id} not found");
                    }
                    _pictureRepository.delete(picture);
                    tx.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void disable(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_enabled = false;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void enable(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_enabled = true;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void makefemale(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_female = true;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void unmakefemale(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_female = false;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }



        public void makemale(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_male = true;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void unmakemale(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_male = false;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void makeSliderImage(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_slider_image = true;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void removeFromSliderImage(long picture_id)
        {
            try
            {
                var picture = _pictureRepository.getById(picture_id);
                if (picture == null)
                {
                    throw new ItemNotFoundException($"{picture_id} not found");

                }
                picture.is_slider_image = false;
                _pictureRepository.update(picture);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void save(PictureDto pictureDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    Picture picture = new Picture();
                    _pictureMaker.copy(picture, pictureDto);
                    _pictureRepository.insert(picture);
                    tx.Complete();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(PictureDto pictureDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    Picture picture = _pictureRepository.getById(pictureDto.picture_id);
                    if (picture == null)
                    {
                        throw new ItemNotFoundException($"Picture with ID {picture.picture_id} doesnot Exist.");
                    }
                    _pictureMaker.copy(picture, pictureDto);
                    _pictureRepository.update(picture);
                    tx.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
