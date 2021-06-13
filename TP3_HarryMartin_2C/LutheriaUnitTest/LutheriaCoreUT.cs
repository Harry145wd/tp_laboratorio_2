using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace LutheriaUnitTest
{
    [TestClass]
    public class LutheriaCoreUT
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            //Act
            Lutheria lutheria = new Lutheria();
            //Assert
            Assert.IsNotNull(lutheria);
            Assert.IsNotNull(lutheria.Afinadora);
            Assert.IsNotNull(lutheria.Almacen);
            Assert.IsNotNull(lutheria.Barnizadora);
            Assert.IsNotNull(lutheria.Encordadora);
            Assert.IsNotNull(lutheria.Limpiadora);
            Assert.IsNotNull(lutheria.InstrumentosEnProceso);
        }

        [TestMethod]
        public void GastarMaterialesFlautaTest()
        {
            //Arrange
            Lutheria lutheria = new Lutheria();
            //Act
            lutheria.GastarMaterialesFlauta();
            //Assert
            Assert.IsTrue(lutheria.Almacen[eMaterial.Madera].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Flauta, eMaterial.Madera].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Metal].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Flauta, eMaterial.Metal].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Plastico].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Flauta, eMaterial.Plastico].CostoDeMaterial));
        }

        [TestMethod]
        public void GastarMaterialesViolinTest()
        {
            //Arrange
            Lutheria lutheria = new Lutheria();
            //Act
            lutheria.GastarMaterialesViolin();
            //Assert
            Assert.IsTrue(lutheria.Almacen[eMaterial.Madera].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Violin, eMaterial.Madera].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Metal].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Violin, eMaterial.Metal].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Plastico].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Violin, eMaterial.Plastico].CostoDeMaterial));
        }

        [TestMethod]
        public void GastarMaterialesGuitarraTest()
        {
            //Arrange
            Lutheria lutheria = new Lutheria();
            //Act
            lutheria.GastarMaterialesGuitarra();
            //Assert
            Assert.IsTrue(lutheria.Almacen[eMaterial.Madera].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Guitarra, eMaterial.Madera].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Metal].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Guitarra, eMaterial.Metal].CostoDeMaterial));
            Assert.IsTrue(lutheria.Almacen[eMaterial.Plastico].Cantidad == (30 - lutheria.Almacen[eTipoInstrumento.Guitarra, eMaterial.Plastico].CostoDeMaterial));
        }

        [TestMethod]
        public void CrearInstrumentoTest()
        {
            //Arrange
            Lutheria lutheria = new Lutheria();
            eTipoInstrumento tipoInstrumento = eTipoInstrumento.Violin;
            string luthier = "Stradivarius";
            DateTime dateTime = DateTime.Now;
            Instrumento instrumento;
            //Act
            instrumento = lutheria.CrearInstrumento(tipoInstrumento, luthier, dateTime);
            //Assert
            Assert.IsNotNull(instrumento);
            Assert.IsTrue(instrumento is Violin);
        }
    }
}
