using ShortestPathAPI.Services;
using ShortestPathWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAPIUnitTest
{
    public class DijkstraServiceTest
    {
        private readonly DijkstraService _dijkstraService;
        private readonly List<Node> _graph;
        public DijkstraServiceTest()
        {
            _dijkstraService = new DijkstraService();
            _graph = new List<Node> {
            new Node { Name = "A", Edges = new List<Edge> { new Edge { Destination = "B" ,Distance= 4 }, new Edge { Destination = "C" ,Distance= 6} } },
            new Node { Name = "B", Edges = new List<Edge> { new Edge {Destination = "A" ,Distance = 4 }, new Edge { Destination = "F" ,Distance= 2 } } },
            new Node { Name = "C", Edges = new List<Edge> { new Edge {Destination = "A" ,Distance = 6 }, new Edge { Destination = "D" ,Distance= 8 } } },
            new Node { Name = "D", Edges = new List<Edge> { new Edge {Destination = "C" ,Distance = 8 }, new Edge { Destination = "E" ,Distance= 4 }, new Edge { Destination = "G", Distance = 1 } } },
            new Node { Name = "E", Edges = new List<Edge> { new Edge {Destination = "B" ,Distance = 2 }, new Edge { Destination = "D" ,Distance= 4 }, new Edge { Destination = "F", Distance = 3 }, new Edge { Destination = "I", Distance = 8 } } },
            new Node { Name = "F", Edges = new List<Edge> { new Edge { Destination = "B", Distance = 2 }, new Edge { Destination = "E", Distance = 3 }, new Edge { Destination = "G", Distance = 4 }, new Edge { Destination = "H", Distance = 6 } } },
            new Node { Name = "G", Edges = new List<Edge> { new Edge { Destination = "D", Distance = 1 }, new Edge { Destination = "F", Distance = 4 }, new Edge { Destination = "H", Distance = 5 }, new Edge { Destination = "I", Distance = 5 } } },
            new Node { Name = "H", Edges = new List<Edge> { new Edge {Destination = "G" ,Distance = 5 }, new Edge { Destination = "F" ,Distance= 6 } } },
            new Node { Name = "I", Edges = new List<Edge> { new Edge {Destination = "E" ,Distance = 8 }, new Edge { Destination = "G" ,Distance= 5 } } }
        };

        }

        [Fact]
        public void ShortestPathValidInput_Returns_CorrectPathAndDistance()
        {
            //Arrange
            var fromNode = "A";
            var toNode = "I";

            //Act
            var result = _dijkstraService.ShortestPath(fromNode, toNode, _graph);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "G", "I" }, result.NodeNames);
            Assert.Equal(15, result.Distance);
        }

        [Fact]
        public void ShortestPathInvalidInput_Throw_Exceptiom()
        {
            //Arrange
            var fromNode = "X";
            var toNode = "Y";

            //Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _dijkstraService.ShortestPath(fromNode, toNode, _graph));
        }

        [Fact]
        public void ShortestPathSameFromAndTo_Returns_ZeroDistance()
        {
            //Arrange
            var fromNode = "A";
            var toNode = "A";

            //Act
            var result = _dijkstraService.ShortestPath(fromNode, toNode, _graph);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A" }, result.NodeNames);
            Assert.Equal(0, result.Distance);
        }

        [Fact]
        public void ShortestPathEmptyFromAndTo_Returns_EmptyPathAndZeroDistance()
        {
            //Arrange
            var fromNode = "";
            var toNode = "";

            //Act
            var result = _dijkstraService.ShortestPath(fromNode, toNode, _graph);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "" }, result.NodeNames);
            Assert.Equal(0, result.Distance);
        }
    }
}
