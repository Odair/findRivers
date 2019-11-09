using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace testes
{
    class Program
    {      
        public List<int> FindRivers(int[,] matriz)
        {

            List<River> matrixRivers = new List<River>();
            int NumberOfRiver = 0;

            for (int i = 0; i < 5; ++i) {
                for (int j = 0; j < 5; ++j) {

                    River rio = new River();
                    rio.Line = i;
                    rio.Column = j;

                    if(matriz[i,j] == 1) {

                        var (PreviusIsRiver, AboveIsRiver) = getAboveAndPreviousRiver(matrixRivers, i,j);

                        if(AboveIsRiver != null || PreviusIsRiver != null)
                        {
                            rio.NumberOfRiver = AboveIsRiver != null ? AboveIsRiver.NumberOfRiver : PreviusIsRiver.NumberOfRiver;
                        }
                        else
                        {
                            NumberOfRiver += 1;
                            rio.NumberOfRiver = NumberOfRiver;
                        }

                        rio.IsRiver = true;
                        matrixRivers.Add(rio);

                    } else {
                        rio.NumberOfRiver = 0;
                        rio.IsRiver = false;
                        matrixRivers.Add(rio);
                    }
                }
            }

            var result = mountResult(matrixRivers);

            return result;
        }

        public (River PreviusIsRiver, River AboveIsRiver) getAboveAndPreviousRiver(List<River> matrixRivers, int line, int column){
            var AboveIsRiver = matrixRivers.FirstOrDefault(r => line != 0 && r.Line == (line -1) && r.Column == column && r.IsRiver == true);
            var PreviusIsRiver = matrixRivers.FirstOrDefault(r => line != 0 && r.Line == line && r.Column == (column -1) && r.IsRiver == true);
            return (PreviusIsRiver, AboveIsRiver);
        }

        public List<int> mountResult(List<River> matrixRivers){
            List<int> list = new List<int>();
            var groupRivers = from r in matrixRivers where r.IsRiver == true group r by r.NumberOfRiver into g select new { count=g.Count() };
            groupRivers.ToList().ForEach(x => {
                list.Add(x.count);
            });

            var orderedList = list != null ? list.OrderBy(x => x).ToList() : null;

            return orderedList;
        }
    }
  
}
