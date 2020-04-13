﻿/******************************************************************************
 *
 *    MIConvexHull, Copyright (C) 2013 David Sehnal, Matthew Campbell
 *
 *  This library is free software; you can redistribute it and/or modify it 
 *  under the terms of  the GNU Lesser General Public License as published by 
 *  the Free Software Foundation; either version 2.1 of the License, or 
 *  (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful, 
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of 
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser 
 *  General Public License for more details.
 *  
 *****************************************************************************/
using OpenTKLib;
namespace MIConvexHull
{
   

    /// <summary>
    /// "Default" vertex.
    /// </summary>
    public class DefaultVertex : IVector
    {
        double[] position; 

        public double this[int index]
        {
            get
            {
                return this.position[index];
            }
            set
            {
                this.position[index] = value;
            }
        }
        public double[] PositionArray
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

    }

}
