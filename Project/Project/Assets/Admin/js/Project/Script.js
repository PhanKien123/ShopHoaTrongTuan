// Phan Đình Kiên : Tìm kiếm thông tin của người dùng 
function SeachUser() {
    $.ajax({
        url: "/User/Seach",
        data: {
            Page: 1,
            FullName: $("#txtSeachNameUser").val(),
            UserName: $("#txtSeachUserName").val(),
            Phone: $("#txtSeachPhoneUser").val(),
            Group: $("#txtSeachGroupUser").val(),
        },
        success: function (result) {
            $("#Table_User").html(result);
        }
    });
}

// Phan Đình Kiên : Lấy ra danh sách người dùng 
function GetListGroupUser() {
    $.ajax({
        url: "/GroupUser/GetListGroup",
        success: function (result) {
            $.each(result, function (i, result) {
                $('#txtSeachGroupUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });

            $.each(result, function (i, result) {
                $('#SelectAddGroupIdUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });

            $.each(result, function (i, result) {
                $('#txtEditGroupUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });



        }
    });
}


// Phan Đình Kiên : Thêm mới thông tin của người dùng 
function AddUser() {

    $.ajax({
        url: "/User/AddUser",
        data: $("#FormAdd_User").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_AdđUser").hide();
                swal("Thông Báo!", "Thêm mới thành công", "success");
            }
            else {

            }
            SeachUser();
        }
    });
}


// Phan Đình Kiên : Cập nhập thông tin của người dùng 
function EditUser() {

    $.ajax({
        url: "/User/EditUser",
        data: $("#Form_EditUser").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_EditUser").hide();
                swal("Thông Báo!", "Cập nhập thành công tài khoản", "success");
            }
            else {

            }
            SeachUser();
        }
    });
}


// Phan Đình Kiên : Lấy thông tin của người dùng theo mã 
function GetUserById(Id) {
    $.ajax({
        url: "/User/GetUserById",
        data: { Id: Id },
        success: function (result) {
            $("#txtEditIdUser").val(result.ID);
            $("#txtEditNameUser").val(result.Name);
            $("#txtEditUserName").val(result.UserName);
            $("#txtEditEmail").val(result.Email);
            $("#txtEditPhone").val(result.Phone);
            $("#txtEditGroupUser").val(result.GroupId);
            if (result.Status == true) {
                $('#txtEditStatusUser').val('true').prop('selected', true);
            }
            else {
                $('#txtEditStatusUser').val('false').prop('selected', true);
            }
            $("#Modal_EditUser").show();
        }
    });
}


// Phan Đình Kiên : Hiển thị ô xác nhân xóa thông tin người dùng 
var IDDelete = 0;
function ShowFromDeleteUser(Id) {
    IDDelete = Id;
    $("#Delete_Users").show();
}

// Phan Đình Kiên : Xóa Thông tin người dùng 
function DelUser() {
    $.ajax({
        url: "/User/DeleteUser",
        data: { Id: IDDelete },
        success: function (result) {
            if (result == 1) {
                $("#Delete_Users").hide();
                swal("Thông Báo!", "Xóa tài khoản thành công", "success");
            }

            SeachUser();
        }
    });
}


//Phan Đình Kiên : Đăng nhập tài khoản vào trang quản lý 
function LoginAdmin() {
    var userName = $("#txtUserName").val();
    var passWord = $("#txtPassword").val();
    $.ajax({
        url: "/User/LoginAction",
        data: { UserName: userName, Password: passWord },
        type: "POST",
        success: function (result) {
            if (result == 1) {
                window.location.href = "/Home/Index";
            }
            else {
                swal("Thông báo lỗi", "(Thông tin tài khoản hoặc mật khẩu không đúng)", "error");
            }
        },
        error: function (errr) {

        }
    });
}


// Phan Đình Kiên : Tìm kiếm thông tin của loại sản phẩm 
function SeachProductCategory() {
    $.ajax({
        url: "/ProductCategory/Seach",
        data: {
            Page: 1,
            ProductCategoryName: $("#txtSeachNameProductCategory").val(),
            GroupCategoryId: $("#txtSeachGroupProductCategory").val()
        },
        success: function (result) {
            $("#Table_ProductCategory").html(result);
        }
    });
}


// Phan Đình Kiên : Lấy thông tin loại sản phẩm 
function getGropProductCategory() {
    $.ajax({
        url: "/ProductCategory/GetSelectProductCategory",
        success: function (result) {
            $.each(result, function (i, result) {
                $('.txtSeachGroupProductCategory').append($('<option>', {
                    value: result.ID,
                    text: result.Name
                }));

            });
        }
    });
}



// Phan Đình Kiên : Thêm mới thông tin loại sản phẩm 
function AddProductCategory() {
    // Lấy thông tin trong ô nhập liệu thông tin chi tiết của loại sản phẩm 
    var value = CKEDITOR.instances['txtAddDescriptionProductCategoryCkeditor'].getData();

    // gán dữ liệu trong thông tin chi tiết của loại sản phẩm vào ô textbox 
    $('#txtAddDescriptionProductCategory').val(value); 
    

    $.ajax({
        type:"POST",
        url: "/ProductCategory/AddProductCategory",
        data: $("#FormAdd_ProductCategory").serialize(),

        success: function (result) {
            if (result == 1) {
                
                window.location = '/ProductCategory/index'; 
                swal("Thông Báo!", "Thêm mới thành công", "success");
            }
            else if(result == -1){
                swal("Thông báo lỗi", "(Tên loại sản phẩm không được phép bỏ trống)", "error");
            }
            SeachProductCategory();
        }
    });
}


// Phan Đình Kiên : Cập nhập thông tin loại sản phâm 
function EditProductCategory() {
    // Lấy thông tin trong ô nhập liệu thông tin chi tiết của loại sản phẩm 
    var value = CKEDITOR.instances['txtEditDescriptionProductCategoryCkeditor'].getData();

    // gán dữ liệu trong thông tin chi tiết của loại sản phẩm vào ô textbox 
    $('#txtEditDescriptionProductCategory').val(value);


    $.ajax({
        type: "POST",
        url: "/ProductCategory/EditProductCategory",
        data: $("#FormEdit_ProductCategory").serialize(),

        success: function (result) {
            if (result == 1) {

                window.location = '/ProductCategory/index';
                swal("Thông Báo!", "Cập nhập thành công", "success");
            }
            else if (result == -1) {
                swal("Thông báo lỗi", "(Tên loại sản phẩm không được phép bỏ trống)", "error");
            }
            else {
                swal("Thông báo lỗi", "(Cập nhập loại sản phẩm thất bại )", "error");
            }
            SeachProductCategory();
        }
    });
}


// Phan Đình Kiên : Hiển thị ô xác nhận xóa thông tin của loại sản phâm r
var IDDeleteProductCategory;
function ShowFromDeletePrductCategory(Id) {
    IDDeleteProductCategory = Id;
    $("#Delete_ProductCategory").show();
}


// Phan Đình Kiên : Xóa Thông tin loại sản phẩm 
function DelProductCategory() {
    
    $.ajax({
        url: "/ProductCategory/DeleteProductCategory",
        //type: "post",
        data: { ProductCategoryId: IDDeleteProductCategory },
        success: function (result) {
            if (result == 1) {
                $("#Delete_ProductCategory").hide();
                swal("Thông Báo!", "Xóa tài Thành công loại Sản phẩm", "success");
            }
            SeachProductCategory();
        }
    });
}


// Phan Đình Kiên : Tìm kiếm thông tin của sản phẩm 

function SeachProduct() {
    $.ajax({
        url: "/Product/Seach",
        data: {
            Page:  1,
            name: $("#txtSeachNameProduct").val(), 
            price: $("#txtSeachProductPrice").val(), 
            quantity: $("#txtSeachQuantityProduct").val(), 
            categoryId: $("#txtSeachGroupProduct").val()
        },
        success: function (result) {
            $("#Table_Product").html(result);
        }
    });
}

// Phan Đình Kiên : Thêm mới thông tin của sản phẩm 

function AddProduct() {
    // Lấy thông tin trong ô nhập liệu thông tin chi tiết của loại sản phẩm 
    var value = CKEDITOR.instances['txtAddDescriptionProductCkeditor'].getData();

    // gán dữ liệu trong thông tin chi tiết của loại sản phẩm vào ô textbox 
    $('#txtAddDescriptionProduct').val(value);
    $.ajax({
        type: "POST",
        url: "/Product/AddProduct",
        data: $("#FormAdd_Product").serialize(),

        success: function (result) {
            if (result == 1) {

                window.location = '/ProductCategory/index';
                swal("Thông Báo!", "Thêm mới thành công", "success");
            }
            else if (result == -1) {
                swal("Thông báo lỗi", "(Tên sản phẩm không được phép bỏ trống)", "error");
            }
            SeachProduct();
        }
    });
}

// Phan Đình Kiên : cập nhập thông tin của sản phẩm

// Phan Đình Kiên : Hiển thị ô xác nhận xóa thông tin sản phẩm 


// Phan Đình Kiên : Xóa thông tin sản phẩm 











// Phan Đình Kiên : load thư viên
$(document).ready(function () {
    getGropProductCategory();
    GetListGroupUser();
});


function SeachFeedback() {
    $.ajax({
        url: "/Feedback/Seach",
        data: {
            Page: 1,
            name: $("#txtSeachNameFeedBack").val(),
            phone: $("#txtSeachPhone").val(),
            address: $("#txtSeachAddr").val(),
        },
        success: function (result) {
            $("#Table_feedback").html(result);
        }
    });
}

function GetFeedbackById(Id) {
    $.ajax({
        url: "/Feedback/UpdateStatus",
        data: { Id: Id },
        success: function (result) {

        }
    });

    $.ajax({
        url: "/Feedback/GetFeedbackById",
        data: { Id: Id },
        success: function (result) {
            $("#txtFeedBackID").val(result.ID);
            $("#txtName").val(result.Name);
            $("#txtEmail").val(result.Email);
            $("#txtPhone").val(result.Phone);
            $("#txtAddress").val(result.Address);
            $("#txtEditContent").append(result.Content);

            if (result.Status == true) {
                $('#txtEditStatusFeedBack').val('true').prop('selected', true);
            }
            else {
                $('#txtEditStatusFeedBack').val('false').prop('selected', true);
            }
            $("#Modal_CheckFeedBack").show();
            SeachFeedback();
        }
    });
}


//-----------------------------------------------------[CONTENT ]-------------------------------------------------


//NGUYỄN NAM ANH : TÌM KIẾM BÀI VIẾT 
function SearchContent() {
    $.ajax({
        url: "/Content/Seach",
        data: {
            Page: 1,
            ContentName: $("#txtSeachNameContent").val(),
            GroupContent: $("#txtSeachGroupContent").val(),
        },
        success: function (result) {
            $("#Table_Content").html(result);
        }
    });
}


// NGUYỄN NAM ANH : THÊM MỚI BÀI VIẾT  ?? 
function AddContent() {

    $.ajax({
        url: "/Content/AddContent",
        data: $("#FormAdd_Content").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_Content").hide();
                swal("Thông Báo!", "Thêm mới thành công", "success");
            }
            else {

            }
            SearchContent();
        }
    });
}

//NGUYỄN NAM ANH : SỦA BÀI VIẾT 
function EditContent() {

    $.ajax({
        url: "/Content/EditContent",
        data: $("#Form_EditContent").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_EditContent").hide();
                swal("Thông Báo!", "Cập nhập thành công tài khoản", "success");
            }
            else {

            }
            SearchContent();
        }
    });
}


// NGUYỄN NAM ANH :  LẤY BÀI VIẾT THEO ID 
function GetContentById(Id) {
    $.ajax({
        url: "/Content/GetContentById",
        data: { Id: Id },
        success: function (result) {
            $("#txtEditIdContent").val(result.ID);
            $("#txtEditNameContent").val(result.Name);
            $("#txtEditImage").val(result.Image);
            $("#txtEditGroupContent").val(result.CategoryID);
            $("#txtEditWarranty").val(result.Warranty);
            $("#txtEditTopHot").val(result.TopHot);
            if (result.Status == true) {
                $('#txtEditStatusContent').val('true').prop('selected', true);
            }
            else {
                $('#txtEditStatusContent').val('false').prop('selected', true);
            }
            $("#Modal_EditContent").show();
        }
    });
}

// NGUYỄN NAM ANH :  XÓA BÁI VIẾT 
var IDDelete = 0;
function ShowFromDeleteContent(Id) {
    IDDelete = Id;
    $("#Delete_Content").show();
}

function DelContent() {
    $.ajax({
        url: "/Content/DeleteContent",
        data: { Id: IDDelete },
        success: function (result) {
            if (result == 1) {
                $("#Delete_Content").hide();
                swal("Thông Báo!", "Xóa tài khoản thành công", "success");
            }

            SearchContent();
        }
    });
}

//-----------------------------------------------------[CATEGORY ]-------------------------------------------------
// NGUYỄN NAM ANH:  TÌM KIẾM THÔNG TIN CHUYÊN MỤC BÀI VIÊT
function SearchCategory() {
    $.ajax({
        url: "/Category/Seach",
        data: {
            Page: 1,
            CategoryName: $("txtSearchNameCategory").val(),
            GroupCategoryId: $("#txtSearchGroupCategory").val(),
        },
        success: function (result) {
            $("#Table_Category").html(result);
        }
    });
}

//NGUYỄN NAM ANH : LẤY THÔNG TIN CHUYÊN MỤC BÀI VIẾT
function getGroupCategory() {
    $.ajax({
        url: "/Category/GetSelectCategory",
        success: function (result) {
            $.each(result, function (i, result) {
                $('.txtSearchGroupCategory').append($('<option>', {
                    value: result.ID,
                    text: result.Name
                }));

            });
        }
    });
}

// NGUYỄN NAM ANH : THÊM MỚI CHUYÊN MỤC BÀI VIẾT 
function AddCategory() {


    var value = CKEDITOR.instances['txtAddDescriptionCategoryCkeditor'].getData();
    $('#txtAddDescriptionCategory').val(value);

    $.ajax({
        type: "POST",
        url: "/Category/AddCategory",
        data: $("#FormAdd_Category").serialize(),

        success: function (result) {
            var data = $("#noidung").val();
            swal("Thông Báo!", data, "success");
            if (result == 1) {
                ///window.location = '/ProductCategory/index'; 
                swal("Thông Báo!", "Thêm mới thành công", "success");
                alert("Thêm mới thành công");
            }
            else {

            }
            SearchCategory();
        }
    });
}


// NGUYỄN NAM ANH : XÓA CHUYÊN MỤC BÀI VIẾT 
var IDDeleteCategory;
function ShowFromDeleteCategory(Id) {
    IDDeleteCategory = Id;
    $("#Delete_Category").show();
}

function DelCategory() {

    $.ajax({
        url: "/Category/DeleteCategory",
        //type: "post",
        data: { CategoryId: IDDeleteCategory },
        success: function (result) {
            if (result == 1) {
                $("#Delete_Category").hide();
                swal("Thông Báo!", "Xóa tài Thành công loại Sản phẩm", "success");
            }
            SearchCategory();
        }
    });
}

