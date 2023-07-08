using Lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTask().Count);
        }
        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("test task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.RemoveTask(0);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTask().Count);           
        }
        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("Test task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.DeleteTask(12478);
            //Assert
            Assert.AreEqual(1, _taskManager.GetTask().Count);
        }        
    }
}
