using Maze.Library;

namespace Maze.Solver
{
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController
    {
        private IRobot robot;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            // Here you have to add your code
            solve(true);



            // Trivial sample algorithm that can just move right
            //var reachedEnd = false;
            /*robot.ReachedExit += (_, __) => reachedEnd = true;

            while (!reachedEnd)
            {
                robot.Move(Direction.Right);
            }
            */
            
        }

        private bool solve(bool parFirstmove)
        {
            var reachedEnd = false;
            robot.ReachedExit += (_, __) => reachedEnd = true;
            Direction lastMove = Direction.Right;
            var firstmove = parFirstmove;
            if (reachedEnd)
            {
                return true;
            }
            else
            {
                if (robot.TryMove(Direction.Right) && (lastMove != Direction.Left || firstmove))
                {
                    lastMove = Direction.Right;
                    solve(false);                   
                }   
                if (robot.TryMove(Direction.Left) && (lastMove != Direction.Right || firstmove))
                {
                    lastMove = Direction.Left;
                    solve(false);
                }
                if (robot.TryMove(Direction.Up) && (lastMove != Direction.Down || firstmove))
                {
                    lastMove = Direction.Up;
                    solve(false);
                }
                if (robot.TryMove(Direction.Down) && (lastMove != Direction.Up || firstmove))
                {
                    lastMove = Direction.Down;
                    solve(false);
                }
            }
            return false;
            
        }
    }
}
