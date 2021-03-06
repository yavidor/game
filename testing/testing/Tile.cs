﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    public class Tile
    {
        #region data
        /// <summary>
        /// the X and Y values in the grid of tiles
        /// </summary>
        public int x, y;
        /// <summary>
        /// row, col = The row and column of the tile in the tileset.
        /// frame = index of the tile in the tilset
        /// </summary>
        public int row, col,frame;
        /// <summary>
        /// The rectangle inside the tileset of this tile
        /// </summary>
        public Rectangle rec;
        /// <summary>
        /// A list of all neighboring tiles. Not including diagonals
        /// </summary>
        public List<Tile> neighbors = new List<Tile>();
        /// <summary>
        /// Can units pass through this tile
        /// </summary>
        public bool walkable = false;
        /// <summary>
        /// The unit in the tile
        /// </summary>
        public Unit unit;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gid">index of the tile in the tilset</param>
        /// <param name="tileCount">flat index of the tile in the grid</param>
        /// <param name="unit">The unit in the tile, sets to null if not provided</param>
        public Tile(int gid, int tileCount, Unit unit=null)
        {
            frame = gid;
            this.unit = unit;
            if (frame == 1005 || frame == 1006 || frame == 942)
                walkable = true;
            col = gid % Game1.tilesetTilesWide;
            this.row = (int)Math.Floor((double)gid / (double)Game1.tilesetTilesWide);

             this.x = (tileCount % Game1.map.Width);
             this.y = (int)Math.Floor(tileCount / (double)Game1.map.Width);

            this.rec = new Rectangle(Game1.tileWidth * col, Game1.tileHeight * row, Game1.tileWidth, Game1.tileHeight);
        }
        public String toString()
        {
            return "col: " + col + " row: " + row + " x:" + x + " y:" + y;
        }
        /// <summary>
        /// Fills the list of neighbors
        /// </summary>
        public void AddNeighbors()
        {
            if (this.x < Game1.map.Width - 1)
            {
                this.neighbors.Add(Game1.Grid[this.x + 1 , this.y]);
            }
            if (this.x > 0)
            {
                this.neighbors.Add(Game1.Grid[this.x - 1 , this.y]);
            }
            if (this.y < Game1.map.Height - 1)
            {
                this.neighbors.Add(Game1.Grid[this.x , this.y + 1]);
            }
            if (this.y > 0)
            {
                this.neighbors.Add(Game1.Grid[this.x , this.y - 1]);
            }
        }
    }
}
