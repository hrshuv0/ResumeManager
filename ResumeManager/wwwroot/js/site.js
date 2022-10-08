// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    $(".custom-file-input").on("change", function () {            
            var fileName = $(this).val().split("\\").pop();
    //alert(fileName);
    $(this).siblings(".custome-file-label").addClass("selected").html(filename);
        });

    function CalcTotalExperiences(){
            var x = document.getElementsByClassName('YearsWorked');

    var totalExp = 0;
    var i = 0;

    for(i = 0; i < x.length; i++)
    {
        totalExp = totalExp + eval(x[i].value);
            }

    document.getElementById('TotalExperience').value = totalExp;

    return;
        }

    document.addEventListener('change', function (e){
            if (e.target.classList.contains('YearsWorked')) {
        CalcTotalExperiences();
            }
        }, false);


    function AddItem(btn)
    {
        let table = document.getElementById("ExpTable");
    let rows = table.getElementsByTagName('tr');

    let rowOuterHtml = rows[rows.length - 1].outerHTML;

    var lastRowIdx = rows.length - 2; // document.getElementById("hdnLastIndex").value;
    var nextRowIdx = eval(lastRowIdx) + 1;
    //document.getElementById("hdnLastIndex").value = nextRowIdx;

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIdx + '_', '_' + nextRowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIdx + ']', '[' + nextRowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastRowIdx, '-' + nextRowIdx);


    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;



        }

    function DeleteItem(btn)
    {
            var table = document.getElementById('ExpTable');
    var rows = table.getElementsByTagName('tr');
    if(rows.length == 2){
        alert("This row cannot be deleted");
    return;
            }

    $(btn).closest('tr').remove();

    CalcTotalExperiences();
        }



