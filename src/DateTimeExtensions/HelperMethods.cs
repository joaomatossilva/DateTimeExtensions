using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions
{
    public static class HelperMethods
    {
        /// <summary>
        /// Returns true if date range of <paramref name="dateAStart"/> and <paramref name="dateAEnd"/> overlaps with range of <paramref name="dateBStart"/> and <paramref name="dateBEnd"/>.
        /// </summary>
        /// <remarks>If <paramref name="dateAStart"/> & <paramref name="dateAEnd"/> overlaps with <paramref name="dateBStart"/> & <paramref name="dateBEnd"/>, it will return the true</remarks>
        /// <param name="dateAStart">Date A start period.</param>
        /// <param name="dateAEnd">Date A end period.</param>
        /// <param name="dateBStart">Date B start period.</param>
        /// <param name="dateBEnd">Date B end period.</param>
        /// <returns>True or false for overlapping date periods</returns>
        public static bool IsOverlapped(DateTime dateAStart, DateTime dateAEnd, DateTime dateBStart, DateTime dateBEnd)
        {
            return dateAStart < dateBEnd && dateBStart < dateAEnd;
        }

        /// <summary>
        /// Returns true if date range of <paramref name="dateAStart"/> and <paramref name="dateAEnd"/> is the same with range of <paramref name="dateBStart"/> and <paramref name="dateBEnd"/>.
        /// </summary>
        /// <remarks>If <paramref name="dateAStart"/> & <paramref name="dateAEnd"/> is the same with <paramref name="dateBStart"/> & <paramref name="dateBEnd"/>, it will return the true</remarks>
        /// <param name="dateAStart">Date A start period.</param>
        /// <param name="dateAEnd">Date A end period.</param>
        /// <param name="dateBStart">Date B start period.</param>
        /// <param name="dateBEnd">Date B end period.</param>
        /// <returns>True or false for the same date periods</returns>
        public static bool IsTheSame(DateTime dateAStart, DateTime dateAEnd, DateTime dateBStart, DateTime dateBEnd)
        {
            return dateAStart == dateBStart && dateAEnd == dateBEnd;
        }

        /// <summary>
        /// Returns true if date range of <paramref name="dateAStart"/> and <paramref name="dateAEnd"/> intersects with range of <paramref name="dateBStart"/> and <paramref name="dateBEnd"/>.
        /// </summary>
        /// <remarks>If <paramref name="dateAStart"/> & <paramref name="dateAEnd"/> intersects with <paramref name="dateBStart"/> & <paramref name="dateBEnd"/>, it will return the true</remarks>
        /// <param name="dateAStart">Date A start period.</param>
        /// <param name="dateAEnd">Date A end period.</param>
        /// <param name="dateBStart">Date B start period.</param>
        /// <param name="dateBEnd">Date B end period.</param>
        /// <returns>True or false for intersecting date periods</returns>
        public static bool IsIntersect(DateTime dateAStart, DateTime dateAEnd, DateTime dateBStart, DateTime dateBEnd)
        {
            return (dateAStart <= dateBEnd && dateBStart <= dateAEnd);
        }

        /// <summary>
        /// Returns true if date range of <paramref name="dateAStart"/> and <paramref name="dateAEnd"/> is inside with range of <paramref name="dateBStart"/> and <paramref name="dateBEnd"/>.
        /// </summary>
        /// <remarks>If <paramref name="dateAStart"/> & <paramref name="dateAEnd"/> is inside within <paramref name="dateBStart"/> & <paramref name="dateBEnd"/>, it will return the true</remarks>
        /// <param name="dateAStart">Date A start period.</param>
        /// <param name="dateAEnd">Date A end period.</param>
        /// <param name="dateBStart">Date B start period.</param>
        /// <param name="dateBEnd">Date B end period.</param>
        /// <returns>True or false for <paramref name="dateAStart"/> & <paramref name="dateAEnd"/> inside of <paramref name="dateBStart"/> & <paramref name="dateBEnd"/> date period</returns>
        public static bool IsInside(DateTime dateAStart, DateTime dateAEnd, DateTime dateBStart, DateTime dateBEnd)
        {
            return (dateAStart >= dateBStart && dateAEnd <= dateBEnd);

        }
    }
}
