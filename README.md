Dijkstra's Algorithm Project
This project demonstrates the implementation of Dijkstra's Algorithm to find the shortest path between nodes. It consists of three components: a Vue.js frontend, an ASP.NET Web API backend, and a .NET Console Application that calculates the shortest path.

Key Features
⦁ Frontend (Vue.js): A user-friendly interface to input nodes (from and to) and display the results of the shortest path.
⦁ Backend (ASP.NET Core Web API): A RESTful API that calculates the shortest path between two nodes using Dijkstra's Algorithm.
⦁ Console Application: A standalone application that reuses the same logic as the API to calculate the shortest path between nodes.
⦁ Testing: Unit tests are provided using xUnit for the backend and Jest for the frontend.

Technologies, Frameworks, and Libraries
⦁ Frontend: Vue.js (Version 3.x)
⦁ Backend: ASP.NET Core Web API with .NET 8
⦁ Console Application: .NET 8
⦁ Testing: Backend: xUnit (for .NET) , Frontend: Jest (for Vue.js)

API Endpoints
⦁ GET /api/ShortestPath/shortestpath?fromNode=A&toNode=I
⦁ Description: Calculates the shortest path between the fromNode (A) and the toNode (I)     using Dijkstra's algorithm.
⦁ Query Parameters:
⦁ fromNode: The starting node.
⦁ toNode: The destination node.
⦁ Response: Returns the shortest path along with the nodes traversed and the total distance.

Instructions
Backend (ASP.NET Core Web API):
⦁ Clone the repository and open the backend project in Visual Studio.
⦁ Adjust Enable cors for the frontend project hosted at http://localhost:8080 in program.cs.
⦁ Build and run the project to start the API.
⦁ The API should be accessible at https://localhost:7014.

Frontend (Vue.js):
⦁ Open the Vue.js application in your browser by navigating to the project directory.
⦁ Run npm install to install dependencies.
⦁ Adjust API URL in App.vue. The API should be accessible at https://localhost:7014.
⦁ Run npm run serve to start the Vue.js application.
⦁ Once the app is running, use the dropdowns to select the "From Node" and "To Node", and click on the "Calculate" button to calculate the shortest path.

Console Application:
⦁ Open the Console Application project in Visual Studio.
⦁ Build and run the application to use the same logic for calculating the shortest path between nodes.
