﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Services;

namespace SandwichOrderSystemShared.Models.Tests
{
    [TestClass()]
    public class OrderTests
    {
        IOrder order;
        IItemFactory itemFactory;
        Mock<IErrorHandler> mockErrorHandler;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            order = new Order();
            itemFactory = new ItemFactory(mockErrorHandler.Object);
        }

        [TestMethod()]
        public void OrderTest_EmptyItemsOnInitialization()
        {
            assertOrderHasNoItems();
        }

        [TestMethod()]
        public void OrderTest_CountEqualsItemsCount()
        {
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            order.Items.Add(sandwich);
            order.Items.Add(sandwich);
            order.Items.Add(sandwich);

            Assert.AreEqual(3, order.Count, "should have items");
            Assert.AreEqual(order.Count, order.Items.Count, "should be equal");
        }

        private void assertOrderHasNoItems()
        {
            Assert.AreEqual(0, order.Count, "should be empty");
        }

        private void setupMocks()
        {
            mockErrorHandler = new Mock<IErrorHandler>();
        }
    }
}