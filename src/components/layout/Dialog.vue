<template>
	<div class="delete-dialog"
    :class="{ 'dialog-hide': isHide }">
        <div class="modal"></div>
        <div class="dialog-box">
            <div class="header">
                <div class="header-title">Thông báo</div>
                <div class="header-exit" @click="btnCloseOnClick()">✕</div>
            </div>
            <div class="body">
                <div class="warning-logo" style="display:none"></div>
                <div class="text-content">
                    <p>Thông báo</p> 
                </div>
            </div>
            <div class="footer">
                <div class="button-right">
                    <button class="btn btn-delete" @click="">Đồng ý</button>
                </div>
            </div>
        </div>
    </div>  
</template>

<script>
import axios from "axios"
export default {
	props: {
        isHide: { type: Boolean, default: true }
    },
    methods: {
        btnCloseOnClick() {
            this.$emit("deleteUser", true);
        }, 
        confirmDelete() {
            axios
            .delete("http://api.manhnv.net/v1/employees/"+ this.employeeId)
            .then((res) => {
                console.log(res);
                this.btnCloseOnClick(); 
            })
            .catch((res) => {
                console.log(res);
            })
        }
    }
}	
</script>

<style scoped>
	.dialog-hide {
    display: none; 
}
.delete-dialog .modal {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #000000;
    opacity: .4;
}
.delete-dialog .dialog-box {
    padding-top: 24px;
    padding-left: 24px;
    padding-right: 24px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-70%,-200%);
    width: 400px;
    border-radius: 4px;
    background-color: #ffffff;
    padding-bottom: 24px;
}
.delete-dialog .header {
    padding-right: 24px;
}
.delete-dialog .header-title {
    font-size: 15px;
    font-weight: bold;
    color: #000000;
}
.delete-dialog .header-exit {
    position: absolute;
    right: 0;
    top: 0;
    text-align: center;
    line-height:40px;
    width: 40px;
    height: 40px;
    cursor: pointer;
}
.delete-dialog .header-exit:hover {
    background-color: #bbbbbb;
    cursor: pointer;
}
.delete-dialog .body {
    padding-top: 24px;
    padding-bottom: 24px;
    display: flex;
}
.delete-dialog .warning-logo {
    position: relative;
    left: 0;
    border-radius: 50%;
    width: 24px;
    height: 24px;
    background-color: #E9EBEE;
}
.delete-dialog .text-content {
    padding-left: 10px;
    display: block;
    width: 100%;
}
.delete-dialog .text-content p {
    margin-top: 0px !important;
    margin-bottom: 5px !important;
}
.delete-dialog .footer {
    position: absolute;
    display: flex;
    align-items: center;
    background-color: #E9EBEE;
    height: 60px;
    border-radius: 0 0 4px 4px;
    left: 0;
    right: 0;
}
.delete-dialog .btn-delete {
    background-color: #ff0000;
}
    .delete-dialog .btn-delete:hover {
        background-color: #F65454;
    }
.delete-dialog .btn-cancel {
    color: #000000;
    background-color: #E9EBEE;
}
.delete-dialog .btn-cancel:hover {
    background-color: #bbbbbb;
}
.delete-dialog .footer {
    
}
.footer .button-left {
    position: absolute;
    right: 110px;
}
.footer .button-right {
    position: absolute;
    right: 24px;
}
</style>