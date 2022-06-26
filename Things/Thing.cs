using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinerGunBuilderCalculator
{
    internal interface IThing
    {
        string Id { get; set; }
        string Name { get; set; }
    }

    public struct Location
    {
        public int X;
        public int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(Location loc)
        {
            return Math.Sqrt((Math.Pow(X - loc.X, 2) + Math.Pow(Y - loc.Y, 2)));
        }
    }

    public abstract class Thing : IThing
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

        //If true,Items that cannot be handled by this program because the calculation method is not known.
        public bool IsNotSupported = false;

        public bool IsAccessFromTOP = false;
        public bool IsAccessFromRIGHT = false;
        public bool IsAccessFromDOWN = false;
        public bool IsAccessFromLEFT = false;
        public bool IsCrossing = false; //Damage crossing,Money crossing
        public bool IsAccessToTOP = false;
        public bool IsAccessToRIGHT = false;
        public bool IsAccessToDOWN = false;
        public bool IsAccessToLEFT = false;

        public bool IsRotatable = true;
        public bool IsRemovable = true;

        protected bool connectionChecked;

        public bool IsLegendary = false;
        public bool IsGuide = false;

        [JsonIgnore]
        public bool IsEjecting = false;

        [JsonIgnore]
        public Random rand;

        [JsonIgnore]
        public abstract string Id { get; set; }

        public abstract string Name { get; set; }

        public Direction direction = Direction.TOP;

        private int dx, dy;

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
        private Thing access_from_abs_top, access_from_abs_right, access_from_abs_down, access_from_abs_left;

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
                return direction switch
                {
                    Direction.TOP => Access_to_abs_top,
                    Direction.RIGHT => Access_to_abs_right,
                    Direction.DOWN => Access_to_abs_down,
                    Direction.LEFT => Access_to_abs_left,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => Access_to_abs_right,
                    Direction.RIGHT => Access_to_abs_down,
                    Direction.DOWN => Access_to_abs_left,
                    Direction.LEFT => Access_to_abs_top,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => Access_to_abs_down,
                    Direction.RIGHT => Access_to_abs_left,
                    Direction.DOWN => Access_to_abs_top,
                    Direction.LEFT => Access_to_abs_right,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => Access_to_abs_left,
                    Direction.RIGHT => Access_to_abs_top,
                    Direction.DOWN => Access_to_abs_right,
                    Direction.LEFT => Access_to_abs_down,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        [JsonIgnore]
        public Thing Access_to_abs_top, Access_to_abs_right, Access_to_abs_down, Access_to_abs_left;

        [JsonIgnore]
        public Thing Access_from_abs_top
        {
            set
            {
                access_from_abs_top = direction switch
                {
                    Direction.TOP => value,
                    Direction.RIGHT => value,
                    Direction.DOWN => value,
                    Direction.LEFT => value,
                    _ => throw new NotImplementedException(),
                };
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
                access_from_abs_right = direction switch
                {
                    Direction.TOP => value,
                    Direction.RIGHT => value,
                    Direction.DOWN => value,
                    Direction.LEFT => value,
                    _ => throw new NotImplementedException(),
                };
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
                access_from_abs_down = direction switch
                {
                    Direction.TOP => value,
                    Direction.RIGHT => value,
                    Direction.DOWN => value,
                    Direction.LEFT => value,
                    _ => throw new NotImplementedException(),
                };
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
                access_from_abs_left = direction switch
                {
                    Direction.TOP => value,
                    Direction.RIGHT => value,
                    Direction.DOWN => value,
                    Direction.LEFT => value,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => access_from_abs_top,
                    Direction.RIGHT => access_from_abs_right,
                    Direction.DOWN => access_from_abs_down,
                    Direction.LEFT => access_from_abs_left,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => access_from_abs_right,
                    Direction.RIGHT => access_from_abs_down,
                    Direction.DOWN => access_from_abs_left,
                    Direction.LEFT => access_from_abs_top,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => access_from_abs_down,
                    Direction.RIGHT => access_from_abs_left,
                    Direction.DOWN => access_from_abs_top,
                    Direction.LEFT => access_from_abs_right,
                    _ => throw new NotImplementedException(),
                };
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
                return direction switch
                {
                    Direction.TOP => access_from_abs_left,
                    Direction.RIGHT => access_from_abs_top,
                    Direction.DOWN => access_from_abs_right,
                    Direction.LEFT => access_from_abs_down,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        [JsonIgnore]
        public Thing Access_from
        {
            get
            {
                if (Access_from_rel_down != null) return Access_from_rel_down;
                if (Access_from_rel_right != null) return Access_from_rel_right;
                if (Access_from_rel_left != null) return Access_from_rel_left;
                if (Access_from_rel_top != null) return Access_from_rel_top;
                return null;
            }
        }

        public bool IsReachable(Thing target_thing)
        {
            foreach (Thing thing in ConnectedThings(true))
            {
                if (thing == target_thing) return true;
            }
            return false;
        }

        public Location GetLocation()
        {
            for (int x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (int y = 0; y < thing_layout.GetLength(1); y++)
                {
                    if (thing_layout[x, y] == this)
                    {
                        return new Location(x, y);
                    }
                }
            }
            throw new Exception();
        }

        public Thing(Thing[,] thing_layout)
        {
            this.thing_layout = thing_layout;
        }

        public virtual void ResetBeforeCalculateDamage()
        {
            rand = new Random(0);
        }

        public virtual ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = new();
            if (Access_from_rel_down != null)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            }
            return inbound_projectileStat;
        }

        public virtual Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = new();
            if (Access_from_rel_down != null)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            }
            return inbound_projectile;
        }

        public void Turn(TurnDirection turn_direction)
        {
            int new_direction = (int)direction + (int)turn_direction;
            direction = (Direction)((new_direction + 4) % 4);
        }

        private void ResetAllThingsCheckConnectionFlag()
        {
            for (var x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (var y = 0; y < thing_layout.GetLength(1); y++)
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
        public IEnumerable<Thing> ConnectedThings(bool isFirstCall = false)
        {
            if (isFirstCall)
            {
                ResetAllThingsCheckConnectionFlag();
            }
            if (connectionChecked == false)
            {
                connectionChecked = true;
                yield return this;
                if (Access_to_abs_top != null)
                {
                    foreach (Thing thing in Access_to_abs_top.ConnectedThings())
                    {
                        yield return thing;
                    }
                }
                if (Access_to_abs_right != null)
                {
                    foreach (Thing thing in Access_to_abs_right.ConnectedThings())
                    {
                        yield return thing;
                    }
                }
                if (Access_to_abs_down != null)
                {
                    foreach (Thing thing in Access_to_abs_down.ConnectedThings())
                    {
                        yield return thing;
                    }
                }
                if (Access_to_abs_left != null)
                {
                    foreach (Thing thing in Access_to_abs_left.ConnectedThings())
                    {
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

            if (distance_x == 0 && (distance_y == 1 || distance_y == -1))
            {
                return false;
            }
            else if (distance_y == 0 && (distance_x == 1 || distance_y == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanReachFromProjectileGenerator(Thing[,] thing_layout, Direction? from_direction = null)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            List<Thing> list_thing;
            Thing thing;
            switch (from_direction)
            {
                case Direction.DOWN:

                    list_thing = thing_1dim_layout.Where(thing => thing.Access_to_abs_top == this).ToList();
                    if (list_thing.Count > 0)
                    {
                        thing = list_thing[0];
                        if (thing is Parts_03_ProjectileGenerator)
                        {
                            return true;
                        }
                        else
                        {
                            return thing.CanReachFromProjectileGenerator(thing_layout);
                        }
                    }
                    else
                    {
                        return false;
                    }
                case Direction.LEFT:
                    list_thing = thing_1dim_layout.Where(thing => thing.Access_to_abs_right == this).ToList();
                    if (list_thing.Count > 0)
                    {
                        thing = list_thing[0];
                        if (thing is Parts_03_ProjectileGenerator)
                        {
                            return true;
                        }
                        else
                        {
                            return thing.CanReachFromProjectileGenerator(thing_layout);
                        }
                    }
                    else
                    {
                        return false;
                    }
                case Direction.TOP:
                    list_thing = thing_1dim_layout.Where(thing => thing.Access_to_abs_down == this).ToList();
                    if (list_thing.Count > 0)
                    {
                        thing = list_thing[0];
                        if (thing is Parts_03_ProjectileGenerator)
                        {
                            return true;
                        }
                        else
                        {
                            return thing.CanReachFromProjectileGenerator(thing_layout);
                        }
                    }
                    else
                    {
                        return false;
                    }
                case Direction.RIGHT:
                    list_thing = thing_1dim_layout.Where(thing => thing.Access_to_abs_left == this).ToList();
                    if (list_thing.Count > 0)
                    {
                        thing = list_thing[0];
                        if (thing is Parts_03_ProjectileGenerator)
                        {
                            return true;
                        }
                        else
                        {
                            return thing.CanReachFromProjectileGenerator(thing_layout);
                        }
                    }
                    else
                    {
                        return false;
                    }
                default:
                    list_thing = thing_1dim_layout.Where(thing => thing.Access_to_abs_top == thing || thing.Access_to_abs_right == thing || thing.Access_to_abs_down == thing || thing.Access_to_abs_left == thing).ToList();
                    if (list_thing.Count > 0)
                    {
                        thing = list_thing[0];
                        if (thing is Parts_03_ProjectileGenerator)
                        {
                            return true;
                        }
                        else
                        {
                            return thing.CanReachFromProjectileGenerator(thing_layout);
                        }
                    }
                    else
                    {
                        return false;
                    }
            }
        }

        protected static Thing Get_access_top_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_y > 0)
            {
                if (thing_layout[from_x, from_y - 1].GetType() == typeof(Parts_Null))
                {
                    return Get_access_top_thing(thing_layout, from_x, from_y - 1);
                }
                else
                {
                    var obj = thing_layout[from_x, from_y - 1];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;

                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;

                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromTOP) return obj;
                            break;

                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected static Thing Get_access_right_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_x < thing_layout.GetLength(0) - 1)
            {
                if (thing_layout[from_x + 1, from_y].GetType() == typeof(Parts_Null))
                {
                    return Get_access_right_thing(thing_layout, from_x + 1, from_y);
                }
                else
                {
                    var obj = thing_layout[from_x + 1, from_y];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;

                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;

                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;

                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromTOP) return obj;
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected static Thing Get_access_left_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_x > 0)
            {
                if (thing_layout[from_x - 1, from_y].GetType() == typeof(Parts_Null))
                {
                    return Get_access_left_thing(thing_layout, from_x - 1, from_y);
                }
                else
                {
                    var obj = thing_layout[from_x - 1, from_y];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;

                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromTOP) return obj;
                            break;

                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;

                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected static Thing Get_access_down_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_y < thing_layout.GetLength(1) - 1)
            {
                if (thing_layout[from_x, from_y + 1].GetType() == typeof(Parts_Null))
                {
                    return Get_access_down_thing(thing_layout, from_x, from_y + 1);
                }
                else
                {
                    var obj = thing_layout[from_x, from_y + 1];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromTOP) return obj;
                            break;

                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;

                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;

                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public virtual void CreateProjectileFlow(Thing[,] thing_layout, Thing fromThing = null, Direction? from_direction = null)
        {
            switch (from_direction)
            {
                case Direction.DOWN:
                    Access_from_abs_down = fromThing;
                    break;

                case Direction.LEFT:
                    Access_from_abs_left = fromThing;
                    break;

                case Direction.TOP:
                    Access_from_abs_top = fromThing;
                    break;

                case Direction.RIGHT:
                    Access_from_abs_right = fromThing;
                    break;
            }

            Thing access_to;
            if (IsAccessToTOP)
            {
                switch (direction)
                {
                    case Thing.Direction.TOP:
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.DOWN);
                        }
                        break;

                    case Thing.Direction.RIGHT:
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.LEFT);
                        }
                        break;

                    case Thing.Direction.DOWN:
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.TOP);
                        }
                        break;

                    case Thing.Direction.LEFT:
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.RIGHT);
                        }
                        break;
                }
            }
            if (IsAccessToRIGHT)
            {
                switch (direction)
                {
                    case Thing.Direction.TOP:
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                        }
                        break;

                    case Thing.Direction.RIGHT:
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                        }
                        break;

                    case Thing.Direction.DOWN:
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                        }
                        break;

                    case Thing.Direction.LEFT:
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                        }
                        break;
                }
            }
            if (IsAccessToDOWN)
            {
                switch (direction)
                {
                    case Thing.Direction.TOP:
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                        }
                        break;

                    case Thing.Direction.RIGHT:
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                        }
                        break;

                    case Thing.Direction.DOWN:
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                        }
                        break;

                    case Thing.Direction.LEFT:
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                        }
                        break;
                }
            }
            if (IsAccessToLEFT)
            {
                switch (direction)
                {
                    case Thing.Direction.TOP:
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                        }
                        break;

                    case Thing.Direction.RIGHT:
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                        }
                        break;

                    case Thing.Direction.DOWN:
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                        }
                        break;

                    case Thing.Direction.LEFT:
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                        }
                        break;
                }
            }
        }
    }
}