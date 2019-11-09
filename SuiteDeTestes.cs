using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace testes
{
    [TestFixture]
    public class SuiteDeTestes
    {
            [Test]       
            public void TestaFindRivers(){

              int[,] matrizMock = new int[,] { 
                {1,0,0,1,0},
                {1,0,1,0,0},
                {0,0,1,0,1},
                {1,0,1,0,1},
                {1,0,1,1,0} 
              };

              Program p = new Program();

              var resultado = p.FindRivers(matrizMock);

              var resultadoEsperado = new List<int>(){1,2,2,2,5};

             Assert.AreEqual(resultadoEsperado, resultado);    
        }
    }
}