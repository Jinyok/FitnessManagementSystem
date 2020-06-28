<template>
    <div class="aside" :style="{backgroundColor: color}">
        <h1 class="asidetitle">
            {{ title }}
        </h1>
        <div v-for="(item, index) in menuList" :key="index">
            <div
                class="button"
                @click="buttonClick(index)"
                @mouseenter="buttonMouseEnter(index)"
                @mouseleave="buttonMouseLeave(index)"
                :style="item.style"
            >
                <p style="margin: 0px;">{{ item.content }}</p>
            </div>
        </div>
        <div style="position:absolute; bottom: 16px;" @click="exit()">
            <p style="color: #ffffff; font-size: 20px; margin: 0px; margin-left: 16px; cursor: pointer">退出</p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Sidebar',
    props: {
        title: String,
        color: String,
        colorHover: String,
        selectedPage: Number,
        listItems: Array
    },
    data: function () {
        var menuList = [];
        var index, item;
        for ([index, item] of this.listItems.entries())
            menuList.push ({
                content: item,
                style: {
                    color: index == this.selectedPage ? this.color : '#ffffff',
                    backgroundColor: index == this.selectedPage ? '#ffffff' : this.color
                }
            });
        return {
            menuList: menuList,
            select: this.selectedPage
        };
    },
    methods: {
        buttonClick(index) {
            if (index == this.select)
                return;
            this.menuList[this.select].style = {
                color: '#ffffff',
                backgroundColor: this.color
            };
            this.select = index;
            this.menuList[this.select].style = {
                color: this.color,
                backgroundColor: '#ffffff'
            };
            this.$emit ('change', index);
        },
        buttonMouseEnter(index) {
            if (this.select != index)
                this.menuList[index].style.backgroundColor = this.colorHover;
        },
        buttonMouseLeave(index) {
            if (this.select != index)
                this.menuList[index].style.backgroundColor = this.color;
        },
        exit () {
            this.$emit ('exit');
        }
    }
}
</script>

<style>
.aside {
    height: 100%;
    width: 240px;
    box-shadow: 2px 0px #cccccc;
    z-index: 0;
}

.aside .asidetitle {
    color: #ffffff;
    font-size: 32px;
    margin-top: 32px;
    margin-bottom: 32px;
    margin-left: 16px;
}

.aside .button {
    padding: 12px 16px;
    font-size: 24px;
    cursor: pointer;
}
</style>