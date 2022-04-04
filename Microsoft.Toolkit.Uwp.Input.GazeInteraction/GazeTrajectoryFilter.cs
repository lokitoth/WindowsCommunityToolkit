using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace Microsoft.Toolkit.Uwp.Input.GazeInteraction
{
    using MSR.IGGazing.MLIntegration;
    using MSR.IGGazing.MLIntegration.Trajectory;
    using Windows.Foundation;

    internal class GazeTrajectoryFilter : IGazeFilter
    {
        private ITrajectoryService trajectoryService;

        public GazeTrajectoryFilter(ITrajectoryService trajectoryService)
        {
            this.trajectoryService = trajectoryService;
        }

        public void LoadSettings(ValueSet settings)
        {
        }

        public GazeFilterArgs Update(GazeFilterArgs args)
        {
            double x = args.Location.X, y = args.Location.Y;
            ulong ticks = (ulong)args.Timestamp.Ticks;
            this.trajectoryService.FixTrajectoryPoint(ref x, ref y, ticks);

            return new GazeFilterArgs(new Point(x, y), args.Timestamp);
        }
    }
}
