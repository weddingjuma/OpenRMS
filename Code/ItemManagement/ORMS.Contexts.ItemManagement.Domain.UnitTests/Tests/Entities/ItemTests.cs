//-----------------------------------------------------------------------
// <copyright file="ItemTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.UnitTests.Tests.Entities
{
    using System;
    using Domain.Entities;
    using FluentAssertions;
    using NUnit.Framework;
    using Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Tests the <see cref="Item"/>
    /// </summary>
    [TestFixture]
    public class ItemTests
    {
        /// <summary>
        /// Given the construction when supplied with default unique identifier then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithDefaultGuid_ThenThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with empty unique identifier then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithEmptyGuid_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.Empty;
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with null name then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithNullName_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = default(Name);
            var description = ShortDescription.Create("Item One");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the name when constructorsupplied valid name then returns constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenConstructorSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the description when constructor given valid value then returns constructed value.
        /// </summary>
        [Test]
        public void GivenDescription_WhenConstructorGivenValidValue_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Description.Should().Be(description);
        }

        /// <summary>
        /// Given the change code method when given null name throws exception.
        /// </summary>
        [Test]
        public void GivenChangeCode_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");
            var item = new Item(id, name, description);

            // ACT
            Action action = () => item.ChangeCode(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change code method when given valid value updates the item.
        /// </summary>
        [Test]
        public void GivenChangeCode_WhenGivenValidValue_UpdatesTheItemName()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var codeUpdated = Code.Create("C0001");
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");
            var item = new Item(id, name, description);

            // ACT
            item.ChangeCode(codeUpdated);

            // ASSERT
            item.Code.Should().Be(codeUpdated);
        }

        /// <summary>
        /// Given the change name method when given null name throws exception.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");
            var item = new Item(id, name, description);

            // ACT
            Action action = () => item.ChangeName(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change name method when given valid value updates the item.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenValidValue_UpdatesTheItemName()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var nameUpdated = Name.Create("Item 1 Deluxe");
            var description = ShortDescription.Create("Item One");
            var item = new Item(id, name, description);

            // ACT
            item.ChangeName(nameUpdated);

            // ASSERT
            item.Name.Should().Be(nameUpdated);
        }

        /// <summary>
        /// Given the change description method when given null description throws exception.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");
            var item = new Item(id, name, description);

            // ACT
            Action action = () => item.ChangeDescription(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change description method when given valid value updates the item description.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenValidValue_UpdatesTheItemDescription()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = Name.Create("Item 1");
            var description = ShortDescription.Create("Item One");
            var descriptionUpdated = ShortDescription.Create("Item One Deluxe");
            var item = new Item(id, name, description);

            // ACT
            item.ChangeDescription(descriptionUpdated);

            // ASSERT
            item.Description.Should().Be(descriptionUpdated);
        }
    }
}