//-- In-browser variables --//

const regex_fieldId = /^[a-z0-9_]+$/;
const regex_fieldName = /^[^:;]+$/;

let formTitle_valid = false;
let formFieldId_valid = false;
let formFieldName_valid = false;

let formFields = [];

//-- Event listeners --//

document.getElementById("formTitleInput").addEventListener("input", function() {
    formTitle_valid = this.value.length > 0;
    updatePreview();
    updateButtons();
});

document.getElementById("formToDateInput").addEventListener("input", updatePreview);

document.getElementById("formToTimeInput").addEventListener("input", updatePreview);

document.getElementById("formFieldId").addEventListener("input", function() {
    formFieldId_valid=!(this.value.length < 1 || !regex_fieldId.test(this.value));
    updateButtons();
});

document.getElementById("formFieldName").addEventListener("input", function() {
    formFieldName_valid=!(this.value.length < 1 || !regex_fieldName.test(this.value));
    updateButtons();
});

document.getElementById("formNewFieldButton").addEventListener("click", addField);

document.getElementById("form").addEventListener("submit", function(e) {
    e.preventDefault();
    submitForm();
});

//-- Functions --//

function updateButtons() {
    document.getElementById("formNewFieldButton").disabled = !(formFieldId_valid && formFieldName_valid);
    document.getElementById("submitButton").disabled = !(formTitle_valid && formFields.length > 0);
}

function updatePreview() {
    const formPreview = document.getElementById("formPreview");
    const formTitle = document.getElementById("formTitleInput").value;
    const formToDate = document.getElementById("formToDateInput").value;
    const formToTime = document.getElementById("formToTimeInput").value;

    let preview = "";

    // Clear the preview
    formPreview.innerHTML = "";

    // Add form title
    preview += `
            <div class="card">
                <div class="card-header text-center h4">${formTitle}</div>
                <div class="card-body">
        `;

    // Add form fields
    formFields.forEach(field => {
        preview += `
                <div class="mb-3">
                    <label class="form-label">${field.name} <span class="text-body-secondary">(${field.id})</span></label>
                    <input type="text" class="form-control form-control-sm">
                </div>
            `;
    });

    // Calculate end time text
    if (formToDate.length > 0) {
        preview += `
                <p class="mb-3"><small>Az űrlapot legkésőbb <b>${formToDate} ${formToTime.length > 0 ? formToTime : "23:59"}</b>-ig lehet beküldeni.</small></p>
            `;
    }

    // Add form end
    preview += `
                <div class="d-flex justify-content-end">
                    <button type="button" class="btn btn-outline-danger btn-sm me-3">Újra kezdés</button>
                    <button type="button" class="btn btn-success btn-sm">Beadás</button>
                </div>
            </div>
        </div>
        `;

    formPreview.innerHTML = preview;
}

function addField() {
    const fieldId = document.getElementById("formFieldId").value;
    const fieldName = document.getElementById("formFieldName").value;

    formFields.push({ id: fieldId, name: fieldName });
    updatePreview();

    document.getElementById("formFieldId").value = "";
    document.getElementById("formFieldName").value = "";
    formFieldId_valid = false;
    formFieldName_valid = false;
    updateButtons();
}

async function submitForm() {
    const formData = new FormData(document.getElementById("form"));
    formData.append("form_fields", formFields.map(f => `${f.id}:${f.name}`).join(";"));

    try {
        const response = await fetch("/CreateForm", {
            method: "POST",
            body: formData,
        });

        if (response.ok) {
            alert(`A(z) "${formData.get("form_title")}" űrlap sikeresen létrehozva!`);
            if (response.redirected) {
                window.location.href = response.url;
            }
        } else {
            console.log(response);
            alert("Hiba történt az űrlap létrehozása közben.");
        }
    } catch (e) {
        console.error(e);
        alert("'fetch' error: " + e.message)
    }
}

//-- Initial setup --//

updateButtons();
updatePreview();