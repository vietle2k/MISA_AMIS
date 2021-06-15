<template>
    <div class="dialog" :class="{'dialog_hide': !isShow}">
        <div id="model">
        <div class="dialog-content">
                <div class="header">
                    <button class="btn-warning"></button>
                    <div style="">Bạn có thực sự muốn xóa Nhân viên "<span> {{this.employeeName}}</span>" không? </div>
                </div>
                <div class="footer">
                    <button class="btn-cancel" @click="hideDialog()">Không</button>
                    <button class="btn-confirm" @click="deleteEmployee()">Có</button>
                </div>
        </div>
        </div>
    </div>
    
</template>
<script>
import axios from "axios";
export default ({
    setup() {
        
    },
    created() {
        
    },
    props: {
        isShow: {
            type: Boolean,
            default: false
        },
        employeeId: { type: String, default: null },
        employeeName: { type: String, default: null },
    },
    methods: {
        hideDialog(){
            this.$emit('hideDialog');
        },
        deleteEmployee() {
            axios
            .delete("https://localhost:44327/api/v1/Employees/"+ this.employeeId)
            .then((res) => {
                console.log(res);
                this.btnCloseOnClick(); 
            })
            .catch((res) => {
                console.log(res);
            })
            this.hideDialog();
        }
    },
    data() {
        return {
            name: null,
        }
    },
})
</script>
<style scoped>
.dialog_hide {
    display:none;
}
#model {
    position: fixed;
    top: 0px;
    left: 0px;
    right: 0px;
    bottom: 0px;
    
    opacity: .3;
    
}
.dialog-content{
    position: fixed;
    width: 444px;
    height: 200px;
    top: calc(50% - 100px);
    left: calc(50% - 222px);
    background-color: white;
    border-radius: 3px;
    box-sizing: border-box;
    padding-left: 28px;
    padding-right: 28px;
    /* background:rgba(253, 255, 254, 0.829); */

}
.header{
    width: 100%;
    height: 60%;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #babec5;
    
}
.footer{
    width: 100%;
    height: 40%;
    display: flex;
    align-items: center;
}
.btn-warning{
    width: 48px;
    height: 48px;
    min-width: 48px;
    min-height: 48px;
    background: url(../../assets/img/Sprites.64af8f61.svg) no-repeat;
    cursor: pointer;
    background-position: -594px -460px;
    border: none;
    outline: none;
    margin-right: 12px;
}
.btn-cancel{
    border: 1px solid #8d9096;
    color: #111;
    background-color: transparent;
    border-radius: 3px;
    height: 36px;
    padding: 8px 20px;
}
.btn-confirm{
    position: absolute;
    right: 24px;
    height: 36px;
    padding: 8px 20px;
    border: 1px solid transparent;
    color: #fff;
    background-color: #2ca01c;
    border-radius: 3px;
}
</style>