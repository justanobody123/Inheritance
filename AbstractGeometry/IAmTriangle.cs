using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal interface IAmTriangle
	{
		double GetLeftAngle();
		double GetRightAngle();
		double GetTopAngle();
		double GetLeftSin();
		double GetRightSin();
		double GetTopSin();
		double GetLeftCos();
		double GetRightCos();
		double GetTopCos();
		double GetLeftSide();
		double GetRightSide();
	}
}
