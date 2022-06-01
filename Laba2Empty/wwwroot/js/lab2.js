const uri = 'api/Categories'; 

let categories = []; 
function getCategories() {
    fetch(uri) 
        .then(response => {
            if (!response.ok) { 
                return response.text().then(text => {
                    throw new Error(text)
                })
            } 
            document.getElementById('errorDB').innerHTML = "";
            return response.json();
        }) 
        .then(data => _displayCategories(data)) 
        .catch(error => document.getElementById('errorDB').innerHTML =
            error.toString());
}
function addCategory() {

    const addCategoryNameTextbox = document.getElementById('add-categoryName');

    const category = {
        categoryName: addCategoryNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(category)
    })
        .then(response => {
            if (!response.ok) { 
                return response.text().then(text => {
                    throw new Error(text)
                })
            } 
            document.getElementById('errorDB').innerHTML = "";
            return response.json();
        }) 
        .then(() => {
            getCategories();
            addCategoryNameTextbox.value = '';
        })
        .catch(error => document.getElementById('errorDB').innerHTML =
            error.toString());
}
function deleteCategory(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCategories())
        .catch(error => document.getElementById('errorDB').innerHTML =
            error.toString());
}
function displayEditForm(id) {
    const category = categories.find(category => category.id === id);

    document.getElementById('edit-id').value = category.id;
    document.getElementById('edit-categoryName').value = category.categoryName;
    document.getElementById('editCategory').style.display = 'block';
}

function updateCategory() {

    const categoryId = document.getElementById('edit-id').value;
    const category = {
        id: parseInt(categoryId, 10),
        categoryName: document.getElementById('edit-categoryName').value.trim(),
    }

    fetch(`${uri}/${categoryId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(category)
    })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => {
                    throw new Error(text)
                })
            }
            document.getElementById('errorDB').innerHTML = "";
            return getCategories();
        })
        .then(() => getCategories())
        .catch(error => document.getElementById('errorDB').innerHTML =
            error.toString());
    closeInput();
    return false;
}
function closeInput() {

    document.getElementById('editCategory').style.display = 'none';
    document.getElementById('errorDB').innerHTML = '';
}
function _displayCategories(data) {
    const tBody = document.getElementById('сategories');
    tBody.innerHTML = '';
    const button = document.createElement('button');
    data.forEach(category => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick',`displayEditForm(${category.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteCategory(${category.id})`);
        let tr = tBody.insertRow(); 
    let td0 = tr.insertCell(0); 
    let textNodeId = document.createTextNode(category.id);
    td0.appendChild(textNodeId);
    let td3 = tr.insertCell(1);
    let textNodeCategoryName = document.createTextNode(category.categoryName);
    td3.appendChild(textNodeCategoryName);
    let td4 = tr.insertCell(2); 
    td4.appendChild(editButton);
    let td5 = tr.insertCell(3); 
    td5.appendChild(deleteButton);
});
categories = data;
}