using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{

    public struct Location
    {
        public int X;
        public int Y;
        public Location(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Thing
    {
        [JsonIgnore]
        public Thing[,] thing_layout;
        public enum Direction
        {
            TOP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }

        public bool IsAccessFromTOP = false;
        public bool IsAccessFromRIGHT = false;
        public bool IsAccessFromDOWN = false;
        public bool IsAccessFromLEFT = false;

        public bool IsAccessToTOP = false;
        public bool IsAccessToRIGHT = false;
        public bool IsAccessToDOWN = false;
        public bool IsAccessToLEFT = false;

        public bool IsRotatable = true;
        public bool IsRemovable = true;

        protected bool connectionChecked;


        public Direction direction = Direction.TOP;

        //debug
        private int dx,dy;
        public int DX
        {
            set
            {
                dx = value;
            }
            get
            {
                return GetLocation().X;
            }
        }
        public int DY
        {
            set
            {
                dy = value;
            }
            get
            {
                return GetLocation().Y;
            }
        }
        // Orientation with respect to the display orientation
        //
        [JsonIgnore]
        private Thing access_from_abs_top, access_from_abs_right,access_from_abs_down,access_from_abs_left;

        [JsonIgnore]
        public Thing Access_to_rel_top
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        Access_to_abs_top = value;
                        break;
                    case Direction.RIGHT:
                        Access_to_abs_right = value;
                        break;
                    case Direction.DOWN:
                        Access_to_abs_down = value;
                        break;
                    case Direction.LEFT:
                        Access_to_abs_left = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return Access_to_abs_top;
                    case Direction.RIGHT:
                        return Access_to_abs_right;
                    case Direction.DOWN:
                        return Access_to_abs_down;
                    case Direction.LEFT:
                        return Access_to_abs_left;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        [JsonIgnore]
        public Thing Access_to_rel_right
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        Access_to_abs_right = value;
                        break;
                    case Direction.RIGHT:
                        Access_to_abs_down = value;
                        break;
                    case Direction.DOWN:
                        Access_to_abs_left = value;
                        break;
                    case Direction.LEFT:
                        Access_to_abs_top = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return Access_to_abs_right;
                    case Direction.RIGHT:
                        return Access_to_abs_down;
                    case Direction.DOWN:
                        return Access_to_abs_left;
                    case Direction.LEFT:
                        return Access_to_abs_top;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        
        [JsonIgnore]
        public Thing Access_to_rel_down
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        Access_to_abs_down = value;
                        break;
                    case Direction.RIGHT:
                        Access_to_abs_left = value;
                        break;
                    case Direction.DOWN:
                        Access_to_abs_top = value;
                        break;
                    case Direction.LEFT:
                        Access_to_abs_right = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return Access_to_abs_down;
                    case Direction.RIGHT:
                        return Access_to_abs_left;
                    case Direction.DOWN:
                        return Access_to_abs_top;
                    case Direction.LEFT:
                        return Access_to_abs_right;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        [JsonIgnore]
        public Thing Access_to_rel_left
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        Access_to_abs_left = value;
                        break;
                    case Direction.RIGHT:
                        Access_to_abs_top = value;
                        break;
                    case Direction.DOWN:
                        Access_to_abs_right = value;
                        break;
                    case Direction.LEFT:
                        Access_to_abs_down = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return Access_to_abs_left;
                    case Direction.RIGHT:
                        return Access_to_abs_top;
                    case Direction.DOWN:
                        return Access_to_abs_right;
                    case Direction.LEFT:
                        return Access_to_abs_down;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        [JsonIgnore]
        public Thing Access_to_abs_top,Access_to_abs_right,Access_to_abs_down,Access_to_abs_left;
        [JsonIgnore]
        public Thing Access_from_abs_top
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_top = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_top = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_top = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_top = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                return access_from_abs_top;
            }
        }
        [JsonIgnore]
        public Thing Access_from_abs_right
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_right = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_right = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_right = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_right = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                return access_from_abs_right;
            }
        }
        [JsonIgnore]
        public Thing Access_from_abs_down
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_down = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_down = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_down = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_down = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                return access_from_abs_down;
            }
        }
        [JsonIgnore]
        public Thing Access_from_abs_left
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_left = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_left = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_left = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_left = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                return access_from_abs_left;
            }
        }


        [JsonIgnore]
        public Thing Access_from_rel_top
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_top = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_right = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_down = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_left = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return access_from_abs_top;
                    case Direction.RIGHT:
                        return access_from_abs_right;
                    case Direction.DOWN:
                        return access_from_abs_down;
                    case Direction.LEFT:
                        return access_from_abs_left;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        [JsonIgnore]
        public Thing Access_from_rel_right
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_right = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_down = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_left = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_top = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return access_from_abs_right;
                    case Direction.RIGHT:
                        return access_from_abs_down;
                    case Direction.DOWN:
                        return access_from_abs_left;
                    case Direction.LEFT:
                        return access_from_abs_top;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        [JsonIgnore]
        public Thing Access_from_rel_down
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_down = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_left = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_top = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_right = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return access_from_abs_down;
                    case Direction.RIGHT:
                        return access_from_abs_left;
                    case Direction.DOWN:
                        return access_from_abs_top;
                    case Direction.LEFT:
                        return access_from_abs_right;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        [JsonIgnore]
        public Thing Access_from_rel_left
        {
            set
            {
                switch (direction)
                {
                    case Direction.TOP:
                        access_from_abs_left = value;
                        break;
                    case Direction.RIGHT:
                        access_from_abs_top = value;
                        break;
                    case Direction.DOWN:
                        access_from_abs_right = value;
                        break;
                    case Direction.LEFT:
                        access_from_abs_down = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            get
            {
                switch (direction)
                {
                    case Direction.TOP:
                        return access_from_abs_left;
                    case Direction.RIGHT:
                        return access_from_abs_top;
                    case Direction.DOWN:
                        return access_from_abs_right;
                    case Direction.LEFT:
                        return access_from_abs_down;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public bool IsReachable(Thing target_thing)
        {
            foreach(Thing thing in ConnectedThings(true))
            {
                if(thing == target_thing)return true;
            }
            return false;
        }

        public Location GetLocation()
        {
            for(int x = 0;x < thing_layout.GetLength(0); x++)
            {
                for(int y = 0;y < thing_layout.GetLength(1); y++)
                {
                    if(thing_layout[x,y] == this)
                    {
                        return new Location(x, y);
                    }
                }
            }
            throw new Exception();
        }

        public Thing(Thing[,] _thing_layout)
        {
            thing_layout = _thing_layout;
        }

        public virtual List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();
            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
            }
            return inbound_projectiles;
        }

        public void Turn(TurnDirection turn_direction)
        {
            int new_direction = (int)direction + (int)turn_direction;
            direction = (Direction)((new_direction + 4) % 4);
        }

        private void ResetAllThingsCheckConnectionFlag()
        {
            for(var x = 0;x < thing_layout.GetLength(0); x++)
            {
                for(var y = 0;y < thing_layout.GetLength(1); y++)
                {
                    thing_layout[x, y].connectionChecked = false;
                }
            }
        }

        /// <summary>
        /// Make a IEnumerable of things that are directly or indirectly connected.
        /// </summary>
        /// <param name="isFirstCall">If true,reset connectionChecked flag to false of all things. </param>
        /// <returns></returns>
        public IEnumerable<Thing> ConnectedThings(bool isFirstCall=false)
        {
            System.Diagnostics.Debug.WriteLine($"@1 {GetLocation().X} {GetLocation().Y} {GetType().Name}");
            if (isFirstCall)
            {
                ResetAllThingsCheckConnectionFlag();
            }
            if(connectionChecked == false){
                connectionChecked = true;
                yield return this;
                if(Access_to_abs_top != null)
                {
                    System.Diagnostics.Debug.WriteLine($"@2 {GetLocation().X} {GetLocation().Y} {GetType().Name} begin foreach access_to_abs_top    ");
                    foreach(Thing thing in Access_to_abs_top.ConnectedThings())
                    {
                        System.Diagnostics.Debug.WriteLine($"@3 {GetLocation().X} {GetLocation().Y} {GetType().Name} -> {thing.GetLocation().X},{thing.GetLocation().Y} {thing.GetType().Name} inside foreach access_to_abs_top    ");
                        yield return thing;
                    }
                }
                if (Access_to_abs_right != null)
                {
                    System.Diagnostics.Debug.WriteLine($"@4 {GetLocation().X} {GetLocation().Y} {GetType().Name} begin foreach access_to_abs_right    ");
                    foreach (Thing thing in Access_to_abs_right.ConnectedThings())
                    {
                        System.Diagnostics.Debug.WriteLine($"@5 {GetLocation().X} {GetLocation().Y} {GetType().Name} -> {thing.GetLocation().X},{thing.GetLocation().Y} {thing.GetType().Name} inside foreach access_to_abs_right    ");
                        yield return thing;
                    }
                }
                if (Access_to_abs_down != null)
                {
                    System.Diagnostics.Debug.WriteLine($"@6 {GetLocation().X} {GetLocation().Y} {GetType().Name} begin foreach access_to_abs_down    ");
                    foreach (Thing thing in Access_to_abs_down.ConnectedThings())
                    {
                        System.Diagnostics.Debug.WriteLine($"@7 {GetLocation().X} {GetLocation().Y} {GetType().Name} -> {thing.GetLocation().X},{thing.GetLocation().Y} {thing.GetType().Name} inside foreach access_to_abs_down    ");
                        yield return thing;
                    }
                }
                if (Access_to_abs_left != null)
                {
                    System.Diagnostics.Debug.WriteLine($"@8 {GetLocation().X} {GetLocation().Y} {GetType().Name} begin foreach access_to_abs_left    ");
                    foreach (Thing thing in Access_to_abs_left.ConnectedThings())
                    {
                        System.Diagnostics.Debug.WriteLine($"@9 {GetLocation().X} {GetLocation().Y} {GetType().Name} -> {thing.GetLocation().X},{thing.GetLocation().Y} {thing.GetType().Name} inside foreach access_to_abs_left    ");
                        yield return thing;
                    }
                }
            }


        }
        public bool IsSeparate(Thing thing_target)
        {
            Location loc_me, loc_target;
            loc_me = GetLocation();
            loc_target = thing_target.GetLocation();
            int distance_x = loc_me.X - loc_target.X;
            int distance_y = loc_me.Y - loc_target.Y;

            if(distance_x ==0 && (distance_y == 1 || distance_y == -1))
            {
                return false;
            }else if(distance_y == 0 && (distance_x == 1 || distance_y == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
