namespace MinerGunBuilderCalculator
{
    public class Crossing : Thing
    {
        public Crossing(Thing[,] thing_layout) : base(thing_layout)
        {
        }

        public override string Id { get; set; } = "--";
        public override string Name { get; set; } = nameof(Crossing);

        public override void CreateProjectileFlow(Thing[,] thing_layout, Thing fromThing = null, Direction? from_direction = null)
        {
            switch (from_direction)
            {
                case Direction.TOP:
                    Access_from_abs_top = fromThing;
                    break;

                case Direction.RIGHT:
                    Access_from_abs_right = fromThing;
                    break;

                case Direction.DOWN:
                    Access_from_abs_down = fromThing;
                    break;

                case Direction.LEFT:
                    Access_from_abs_left = fromThing;
                    break;
            }

            Thing access_to;
            // Access to top
            switch (direction)
            {
                case Thing.Direction.TOP:
                    if (from_direction == Direction.DOWN)
                    {
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.DOWN);
                        }
                    }
                    break;

                case Thing.Direction.RIGHT:
                    if (from_direction == Direction.LEFT)
                    {
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.LEFT);
                        }
                    }
                    break;

                case Thing.Direction.DOWN:
                    if (from_direction == Direction.TOP)
                    {
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.TOP);
                        }
                    }
                    break;

                case Thing.Direction.LEFT:
                    if (from_direction == Direction.RIGHT)
                    {
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Direction.RIGHT);
                        }
                    }
                    break;
            }

            // Access to right
            switch (direction)
            {
                case Thing.Direction.TOP:
                    if (from_direction == Direction.LEFT)
                    {
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                        }
                    }
                    break;

                case Thing.Direction.RIGHT:
                    if (from_direction == Direction.TOP)
                    {
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                        }
                    }
                    break;

                case Thing.Direction.DOWN:
                    if (from_direction == Direction.RIGHT)
                    {
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                        }
                    }
                    break;

                case Thing.Direction.LEFT:
                    if (from_direction == Direction.DOWN)
                    {
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                        }
                    }
                    break;
            }

            // Access to down

            switch (direction)
            {
                case Thing.Direction.TOP:
                    if (from_direction == Direction.TOP)
                    {
                        access_to = Get_access_down_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_down = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                        }
                    }
                    break;

                case Thing.Direction.RIGHT:
                    if (from_direction == Direction.RIGHT)
                    {
                        access_to = Get_access_left_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_left = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                        }
                    }
                    break;

                case Thing.Direction.DOWN:
                    if (from_direction == Direction.DOWN)
                    {
                        access_to = Get_access_top_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_top = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                        }
                    }
                    break;

                case Thing.Direction.LEFT:
                    if (from_direction == Direction.LEFT)
                    {
                        access_to = Get_access_right_thing(thing_layout, DX, DY);
                        if (access_to != null)
                        {
                            Access_to_abs_right = access_to;
                            access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                        }
                    }
                    break;
            }

            // Access to left
            {
                switch (direction)
                {
                    case Thing.Direction.TOP:
                        if (from_direction == Direction.RIGHT)
                        {
                            access_to = Get_access_left_thing(thing_layout, DX, DY);
                            if (access_to != null)
                            {
                                Access_to_abs_left = access_to;
                                access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.RIGHT);
                            }
                        }
                        break;

                    case Thing.Direction.RIGHT:
                        if (from_direction == Direction.DOWN)
                        {
                            access_to = Get_access_top_thing(thing_layout, DX, DY);
                            if (access_to != null)
                            {
                                Access_to_abs_top = access_to;
                                access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.DOWN);
                            }
                        }
                        break;

                    case Thing.Direction.DOWN:
                        if (from_direction == Direction.LEFT)
                        {
                            access_to = Get_access_right_thing(thing_layout, DX, DY);
                            if (access_to != null)
                            {
                                Access_to_abs_right = access_to;
                                access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.LEFT);
                            }
                        }
                        break;

                    case Thing.Direction.LEFT:
                        if (from_direction == Direction.TOP)
                        {
                            access_to = Get_access_down_thing(thing_layout, DX, DY);
                            if (access_to != null)
                            {
                                Access_to_abs_down = access_to;
                                access_to.CreateProjectileFlow(thing_layout, this, Thing.Direction.TOP);
                            }
                        }
                        break;
                }
            }
        }
    }
}