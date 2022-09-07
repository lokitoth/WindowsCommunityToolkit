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
        private IGazePointerIntegrationEx gazePointerIntegration;

        public GazeTrajectoryFilter(IGazePointerIntegrationEx gazePointerIntegration)
        {
            this.gazePointerIntegration = gazePointerIntegration;
        }

        public void LoadSettings(ValueSet settings)
        {
        }

        public GazeFilterArgs Update(GazeFilterArgs args)
        {
            double x = args.Location.X, y = args.Location.Y;
            ulong ticks = args.Timestamp.ToGazeTicks();

            this.gazePointerIntegration.FilterGazeCoordinates(ref x, ref y, ticks);

            return new GazeFilterArgs(new Point(x, y), args.Timestamp);
        }
    }
}
