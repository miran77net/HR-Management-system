function filterTable() {
    let fromDate = document.getElementById("fromDate").value;
    let toDate = document.getElementById("toDate").value;

    let table = document.getElementById("attendanceTable");
    let rows = table.getElementsByTagName("tr");

    for (let i = 1; i < rows.length; i++) {
        let dateCell = rows[i].getElementsByTagName("td")[1];

        if (dateCell) {
            let rowDate = new Date(dateCell.innerText);

            let show = true;

            if (fromDate) {
                let from = new Date(fromDate);
                if (rowDate < from) show = false;
            }

            if (toDate) {
                let to = new Date(toDate);
                if (rowDate > to) show = false;
            }

            rows[i].style.display = show ? "" : "none";
        }
    }
}