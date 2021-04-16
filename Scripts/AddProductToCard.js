function AddToCart(productId, description, photourl, productPrice, productTitle) {
    /**
     * This paraters are comes from product selection page.
     * Firstly creating form data for send to controller.
     */
    var product = {};
    product.ProductId = productId;
    product.ProductDesc = description;
    product.ProductPrice = productPrice;
    product.ProductPhotoURL = photourl;
    product.ProductTitle = productTitle;

    $.ajax({
        type: "POST",
        url: "/{Controller Name}/{Function Name}",
        data: JSON.stringify({'giftData': product}) ,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            /**
             * Data is returned data from controller side.
             */
            document.getElementById("cartItems").innerHTML = data.countProductInCart;
        },
        error: function () {
            alert("Error occured!!");
            console.log(data);
        }
    });

}


/**
 * This function for update user Id number.
 * Id number length is must be 11 and cannot contain alphabetic character. 
 * This function takes two parameters. One of the parameters is the field name and the other is the field value.
 * Example: ("IdNumber",53617501341). It sends the data containing the field name and field value to be changed.
 * */
 function updateIban() {
    const IdNumber = document.getElementById("IdNumber").value;
    console.log(IbanNo);
    if (IdNumber !== null || IdNumber.length === 11) {
        const participant = {};
        participant.fieldName = "IdNumber";
        participant.fieldValue = $("#IdNumber").val();
        $.ajax({
            type: "POST",
            url: "/{controller Name}/{Function Name}",
            data: JSON.stringify({'UserData':participant}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.success) {
                    document.getElementById("IdNumber").innerHTML = data.newIdNumber;
                } else {
                    alert("Please control Id Number");
                }
            },
            error: function () {
                alert("An Error Occured (Update)!!");

            }
        });
    } else {
        alert("Input Error!!!");
    }

}

