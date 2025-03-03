using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGame
{
    public class MapTile
    {
        public TileType TileType { get; set; }
        public bool IsActive { get; set; }//맵 활성화 상태
        public MapTile()
        {
            TileType = TileType.Hide;
            IsActive = false;
        }
        public void DrawTile()
        {
            if (IsActive)
            {
                switch (TileType)
                {
                    case TileType.None: Console.Write("🟩"); break;
                    case TileType.Hide: Console.Write("📝"); break;
                    case TileType.Shelter: Console.Write("🏕️"); break;
                    case TileType.Item: Console.Write("🎁"); break;
                    case TileType.WildAnimal: Console.Write("💻"); break;
                    case TileType.Radio: Console.Write("📡"); break;// 무전기
                }
            }
            else
            {
                Console.Write("❌");
            }
        }//void DrawTile()
    }//clas MapTile

}
