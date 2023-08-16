
var DeleteCustomer = function (id) {
    Swal.fire({
        title: 'Do you want to delete this Customer?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: "Customer/DeleteConfirmed/" + id,
                success: function (result) {
                    var message = "Costomer has been deleted successfully.";
                    Swal.fire({
                        title: message,
                        icon: 'info',
                        onAfterClose: () => {
                            location.reload();
                        }
                    });
                },
                error: function () {
                    var message = "Costomer addresses have not been deleted yet.";
                    Swal.fire({
                        title: message,
                        icon: 'info',
                        onAfterClose: () => {
                            location.reload();
                        }
                    });
                }
            });
        }
    });
};