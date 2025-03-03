using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace SurvivalGame
{
    public class EventMnager
    {
        //private MapManager _mapManager;
        Random _rand;
        public EventMnager()
        {
            _rand = SurvivalGame.random;
        }

        public EventResult HandleEvent(TileType tileType)
        {
            EventResult eventResult = EventResult.None;

            switch (tileType)
            {
                case TileType.WildAnimal:
                    HandleWildAnimalEvent(out eventResult);
                    break;
                case TileType.Item:
                    HandleItemEvent(out eventResult);
                    break;
                case TileType.Radio:
                    eventResult = EventResult.RadioAcquired;
                    break;
                case TileType.None:
                    eventResult = EventResult.None;
                    break;
                case TileType.Shelter:
                    eventResult = EventResult.ArrivedAtShelter;
                    break;
            }

            return eventResult;
        }

        private void HandleWildAnimalEvent(out EventResult eventReuslt)
        {
            int chance = _rand.Next(1, 101);
            if (chance<=70)// 70% 확률로 데미지
            {
                eventReuslt = EventResult.TookDamage;
            }
            else
            {
                eventReuslt = EventResult.EvadedWildAnimal;
            }
        }

        private void HandleItemEvent(out EventResult eventResult)
        {
            //20퍼센트 확률로 최대 스태미너 회복
            int chance = _rand.Next(1, 101);
            if (chance <= 25)//20퍼센트 확률로 맵 확장 
            {
                eventResult = EventResult.MapExpansion;
            }
            else if(chance <= 50)//25퍼센트 확률로 최대 스태미나 증가
            {
                eventResult = EventResult.MaxStaminaIncreased;
            }
            else if (chance<= 75)//25퍼센트 확률로 최대 체력 증가
            {
                eventResult = EventResult.MaxHealthIncreased;
            }
            else if (chance <= 90) //15퍼센트 확률로 체력 회복
            {
                eventResult = EventResult.HealthRecovered;
            }
            else //10퍼센트 확률로 현재 스태미너 회복
            {
                eventResult = EventResult.StaminaRecovered;
            }
        }
    }


}
