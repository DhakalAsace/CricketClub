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
   public class PlayerProfileServiceImpl : PlayerProfileService
    {
        private readonly PlayerProfileRepository _playerProfileRepository;
        private readonly PlayerProfileMaker _playerProfileMaker;

        public PlayerProfileServiceImpl(PlayerProfileRepository playerProfileRepository, PlayerProfileMaker playerProfileMaker)
        {
            _playerProfileRepository = playerProfileRepository;
            _playerProfileMaker = playerProfileMaker;

        }
        public void delete(long player_profile_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var playerProfile = _playerProfileRepository.getById(player_profile_id);
                    if (playerProfile == null)
                    {
                        throw new ItemNotFoundException($" {player_profile_id} not found");
                    }
                    _playerProfileRepository.delete(playerProfile);
                    tx.Complete();
                 }
                }
                 catch (Exception)
            {
                throw;
            }
        }

        

        public void disable(long player_profile_id)
        {
            try
            {
                var playerProfile = _playerProfileRepository.getById(player_profile_id);
                if(playerProfile == null)
                {
                    throw new ItemNotFoundException($"{player_profile_id} not found");

                }
                playerProfile.is_enabled = false;
                _playerProfileRepository.update(playerProfile);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void enable(long player_profile_id)
        {
            try
            {
                var playerProfile = _playerProfileRepository.getById(player_profile_id);
                if(playerProfile == null)
                {
                    throw new ItemNotFoundException($" {player_profile_id} not found");
                }
                playerProfile.is_enabled = true;
                _playerProfileRepository.update(playerProfile);
            }
            catch (Exception)
            {
                throw;
            }
        }


     
        public void save(PlayerProfileDto playerProfileDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    PlayerProfile playerProfile = new PlayerProfile();
                    _playerProfileMaker.copy(playerProfile, playerProfileDto);
                    _playerProfileRepository.insert(playerProfile);
                    tx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(PlayerProfileDto playerProfileDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope (TransactionScopeOption.Required))
                {
                    PlayerProfile playerProfile = _playerProfileRepository.getById(playerProfileDto.player_profile_id);
                    if (playerProfile == null)
                    {
                        throw new ItemNotFoundException($"PlayerProfile with ID {playerProfile.player_profile_id} doesnot Exist.");
                    }
                    _playerProfileMaker.copy(playerProfile, playerProfileDto);
                    _playerProfileRepository.update(playerProfile);
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
