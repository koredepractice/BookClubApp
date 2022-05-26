// JavaScript source code for BookClubApp
/****************************************************************************
    * Add a new Book.
    *
    * 1) send an update to the DB
    * 2) if successful then add the book to the list
    ****************************************************************************/
function addNewBook(newBookValue) {

    // Get the value for the book table from the Input field in the FORM
    let bookTitleValue = document.getElementById("newBookTitle").value.trim();
    let bookAuthorNameValue = document.getElementById("newBookAuthorName").value.trim();
    let bookYearOfPublicationValue = document.getElementById("newbookYearOfPublication").value.trim();

    // Check that a value have added
    if (bookTitleValue === "") {
        alert("Please enter a book title");
    }
    createBook(bookValue);
    document.getElementById("newBookEntry").value = "";
}

/****************************************************************************
 * This function will add the a new book item to the UL element
 * Specifically this will add:
 *
 *   <li>bookentry<span class="close">X</>li>
 *
 * 1) add to DB
 * 2) if successful then add the item to the list
 *
 ****************************************************************************/
function addBookToDisplay(item) {
    let BookNode = document.createElement("li");
    let descriptionTextNode = document.createTextNode(item["description"]);
    todoItemNode.appendChild(descriptionTextNode);

    document.getElementById("todoList").appendChild(todoItemNode);

    let tickSpanNode = document.createElement("SPAN");
    let tickText = document.createTextNode("\u2713");  // \u2713 is unicode for the tick symbol
    tickSpanNode.appendChild(tickText);
    todoItemNode.appendChild(tickSpanNode);
    tickSpanNode.className = "tickHidden";

    let closeSpanNode = document.createElement("SPAN");
    let closeText = document.createTextNode("X");
    closeSpanNode.className = "close";
    closeSpanNode.appendChild(closeText);
    todoItemNode.appendChild(closeSpanNode);

    closeSpanNode.onclick = function (event) {
        // When the use press the "X" button, the click event is normally also passed to its parent element.
        // (i.e. the element containing the <SPAN>). In the case the LI element that is holding the TodoItem
        // which would have resulted in a toggle of item between "DONE" and "NEW"
        //
        // stopPropagation() tells the event not to propagate
        event.stopPropagation();

        if (confirm("Are you sure that you want to delete " + item.description + "?")) {
            deleteTodoItem(item["id"]);

            // Remove the HTML list element that is holding this todo item
            todoItemNode.remove();
        }
    }

    todoItemNode.onclick = function () {
        if (item["status"] === "NEW") {
            item["status"] = "DONE"
        } else {
            item["status"] = "NEW"
        }

        updateTodoItem(item);

        todoItemNode.classList.toggle("checked");
        tickSpanNode.classList.toggle("tickVisible");
    }

    if (item["status"] !== "NEW") {
        todoItemNode.classList.toggle("checked");
        tickSpanNode.classList.toggle("tickVisible");
    }
}

/****************************************************************************
 * CRUD functions calling the REST API
 ****************************************************************************/

function createTodoItem(bookTitleValue,) {

    // Create a new JSON object for the new item with the status of NEW
    // Since the id is generated by the microservice, we will use -1 as a dummy
    // If the POST is successful the microservice will store the new item in the database
    // and returns a JSON via the response with the generated id for the new item
    const newItem = { "Title": todoItemDescription, "AuthorName": "NEW", "YearOfPublication" : "NEW2" };
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newItem)
    };
    fetch('https://localhost:7167/', requestOptions)
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to create the TODO item")
                throw response.status;
            } else return response.json();
        })

        // add the item to the UL element so that it will appear in the browser
        .then(item => addTodoItemToDisplay(item));
}

// Load the list - expecting an array of todo_items to be returned
function readBooks() {
    fetch('https://localhost:7167/')
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to read the TODO list")
                throw response.status;
            } else return response.json();
        })
        // Add the items to the UL element so that it can be seen
        // As items is an array, we will the array.map function to through the array and add item to the UL element
        // for display
        .then(items => items.map(item => addTodoItemToDisplay(item)));
}

function updateTodoItem(item) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item)
    };
    fetch('https://localhost:7167/' + item.id, requestOptions)
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to UPDATE the TODO item")
                throw response.status;
            } else return response.json();
        })
}

function deleteTodoItem(todoItemId) {
    fetch("https://localhost:7167/" + todoItemId, { method: 'DELETE' })
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to DELETE the TODO item")
                throw response.status;
            } else return response.json();
        })
}