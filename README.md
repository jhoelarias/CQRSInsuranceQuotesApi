# CoterieApi

## Application execution and testing steps
 
  1. Clone the repository.
  2. Open the solution in the root of the project.
  3. Execute the application using IIS Expressthe default browser will show a swagger window.
  4. Find the controller named Quote and click on the endpoint named /Quote/CalculateQuote, and click on Try Out.
  5. Paste the following payload in the request body
    ```
    {
      "business": "Plumber",
      "revenue": 6000000,
      "states": [
        "TX",
        "OH",
        "FLORIDA"
      ]
    }
    ```
  6. Click on execute. 
  7. Scroll down and you will see the response Body with the results