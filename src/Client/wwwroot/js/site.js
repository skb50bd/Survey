const d1 = document.getElementById("D1");
const d1Add = document.getElementById("D1-add");

const d2 = document.getElementById("D2");
const d2Add = document.getElementById("D2-add");

const d4 = document.getElementById("D4");
const d4Add = document.getElementById("D4-add");

const d6a = document.getElementById("D6A");
const d6aAdd = document.getElementById("D6A-add");

const e1b = document.getElementById("E1B");
const e1bAdd = document.getElementById("E1B-add");

const g2 = document.getElementById("G2");
const g2Add = document.getElementById("G2-add");


function createNewD1(index) {
    const div = document.createElement("div");
    div.className = "mt-1";
    div.innerHTML =
        `
            <input name="Input.D1.Index" value="${index}" hidden />
            <input name="Input.D1[${index}]"
                   class="form-control form-control-sm col-md-6 d1-entry" 
                   placeholder="Name of Company Leader"
                   type="text" />
        `;
    return div;
}

function addD1(event) {
    event.preventDefault();

    const index = d1.children.length;
    const div = createNewD1(index);
    $(div).hide().appendTo(d1).fadeIn(500);
}

function createNewD2(index) {
    const div = document.createElement("div");
    div.className = "mt-1";
    div.innerHTML =
        `
            <input name="Input.D2.Index" value="${index}" hidden />
            <input name="Input.D2[${index}]"
                   class="form-control form-control-sm col-md-6 d2-entry" 
                   placeholder="Name of Company Employee"
                   type="text" />
        `;
    return div;
}

function addD2(event) {
    event.preventDefault();

    const index = d2.children.length;
    const div = createNewD2(index);
    $(div).hide().appendTo(d2).fadeIn(500);
}

function createNewD4(index) {
    const div = document.createElement("div");
    div.className = "card mt-1";
    div.innerHTML = `
    <div class="card-body pt-0">
                <input name="Input.D4A.Index" value="${index}" hidden />
                <input name="Input.D4B.Index" value="${index}" hidden />
                <input name="Input.D4C.Index" value="${index}" hidden />
                <input name="Input.D4D.Index" value="${index}" hidden />

                <div class="mt-2">
                    <label class="text-justify mb-0"
                           style="font-weight: 400">
                        a. Name
                    </label>

                    <input name="Input.D4A[${index}]"
                           class="form-control form-control-sm col-md-6 d4a-entry" 
                           type="text"/>
                </div>

                <div class="mt-2">
                    <label class="text-justify mb-0"
                           style="font-weight: 400">
                        b. Last Title
                    </label>

                    <input name="Input.D4B[${index}]"
                           class="form-control form-control-sm col-md-6 d4b-entry"
                           type="text"/>
                </div>

                <div class="mt-2">
                    <label class="text-justify mb-0"
                           style="font-weight: 400">
                        c. Employment/position hire date
                    </label>

                    <input name="Input.D4C[${index}]"
                           class="form-control form-control-sm col-md-6 d4c-entry"
                           type="date" />
                </div>

                <div class="mt-2">
                    <label class="text-justify mb-0"
                           style="font-weight: 400">
                        d. Employment/position termination date
                    </label>

                    <input name="Input.D4D[${index}]"
                           class="form-control form-control-sm col-md-6 d4d-entry"
                           type="date" />
                </div>
            </div>
        `;
    return div;
}

function addD4(event) {
    event.preventDefault();

    const index = d4.children.length;
    const div = createNewD4(index);
    $(div).hide().appendTo(d4).fadeIn(500);
}

function createNewD6A(index) {
    const div = document.createElement("div");
    div.className = "mt-1";
    div.innerHTML =
        `
            <input name="Input.D6A.Index" value="${index}" hidden />
            <input name="Input.D6A[${index}]"
                   class="form-control form-control-sm col-md-6 d6a-entry" 
                   placeholder="Name"
                   type="text" />
        `;
    return div;
}

function addD6A(event) {
    event.preventDefault();

    const index = d6a.children.length;
    const div = createNewD6A(index);
    $(div).hide().appendTo(d6a).fadeIn(500);
}

function removeE1B(event) {
    event.preventDefault();

    var inp = event.target;
    inp.setAttribute("disabled");
    inp.parentElement.setAttribute("hidden");
}

function createNewE1B(index) {
    const div = document.createElement("div");
    div.className = "mt-1";
    div.innerHTML =
        `
            <input name="Input.E1B.Index" value="${index}" hidden />
            <input name="Input.E1B[${index}]"
                   class="form-control form-control-sm col-md-6 e1b-entry" 
                   placeholder="Name of Company Leader or Employee"
                   type="text" />
        `;
    return div;
}

function addE1B(event) {
    event.preventDefault();

    const index = e1b.children.length;
    const div = createNewE1B(index);
    $(div).hide().appendTo(e1b).fadeIn(500);
}

function createNewG2(index) {
    const div = document.createElement("div");
    div.className = "card mt-1";
    div.innerHTML = `
       <div class="card-body pt-0">
                    <input name="Input.G2A.Index" value="${index}" hidden />
                    <input name="Input.G2B.Index" value="${index}" hidden />
                    <input name="Input.G2C.Index" value="${index}" hidden />
                    <input name="Input.G2D.Index" value="${index}" hidden />

                    <div class="mt-2">
                        <label class="text-justify mb-0"
                               style="font-weight: 400">
                            a. Sub-agent business name
                        </label>

                        <input name="Input.G2A[${index}]"
                               class="form-control form-control-sm col-md-6 g2a-entry"
                               type="text" />
                    </div>

                    <div class="mt-2">
                        <label class="text-justify mb-0"
                               style="font-weight: 400">
                            b. Primary sub-agent contact
                        </label>

                        <input name="Input.G2B[${index}]"
                               class="form-control form-control-sm col-md-6 g2b-entry"
                               type="text" />
                    </div>

                    <div class="mt-2">
                        <label class="text-justify mb-0"
                               style="font-weight: 400">
                            c. Sub-agent e-mail
                        </label>

                        <input name="Input.G2C[${index}]"
                               class="form-control form-control-sm col-md-6 g2c-entry"
                               type="text" />
                    </div>

                    <div class="mt-2">
                        <label class="text-justify mb-0"
                               style="font-weight: 400">
                            d. Services to be provided by sub-agent
                        </label>

                        <textarea name="Input.G2D[${index}]"
                                  class="form-control form-control-sm col-md-6 g2d-entry">
                        </textarea>
                    </div>
                </div>
    `;
    return div;
}

function addG2(event) {
    event.preventDefault();

    const index = g2.children.length;
    const div = createNewG2(index);
    $(div).hide().appendTo(g2).fadeIn(500);
}


$(document).ready(function () {
    bsCustomFileInput.init();

    d1Add.onclick = addD1;
    d2Add.onclick = addD2;
    d4Add.onclick = addD4;
    d6aAdd.onclick = addD6A;
    e1bAdd.onclick = addE1B;
    g2Add.onclick = addG2;
});

