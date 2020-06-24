<template>
    <div class = "CoachSection">
        <div class = "card" style="cursor: pointer; justify-content: flex-start" @click="goBack">
            <img src="../../assets/imgs/jumpD_Reverse.png" 
                style="max-width: 30px; float:left; margin-right: 12px">
            <div style="font-size: 25px; margin-top: -3px">返回</div>
        </div>
        <br>
        <div class = "card">
            <p style="font-size: 40px; margin: 15px 5px">{{ sections.Title }}</p>
        </div>
    </div>
</template>

<script>
import methods from '../../methods'
export default {
    name: 'coachsection',
    data () {
        return {
            sections: {
                SectionId   : 1,
                Title       : '三个月瘦身速成不瘦不要钱',
                ClassHour   : 15,
                Progress    : 12,
                Member      : [
                    {
                        MemberId    : '01222010',
                        Name        : 'Alice',
                        PhoneNo     : '180-1072-1101'
                    },
                    {
                        MemberId    : '01222011',
                        Name        : 'Bill',
                        PhoneNo     : '138-1232-2132'
                    },
                    {
                        MemberId    : '01222012',
                        Name        : 'Alice',
                        PhoneNo     : '180-1013-3242'
                    },
                    {
                        MemberId    : '01222013',
                        Name        : 'Alice',
                        PhoneNo     : '180-4657-9435'
                    },
                    {
                        MemberId    : '01222014',
                        Name        : 'Alice',
                        PhoneNo     : '131-1455-1762'
                    },
                    {
                        MemberId    : '01222015',
                        Name        : 'Alice',
                        PhoneNo     : '139-3425-9335'
                    },
                ]
            }
        }
    },
    methods: {
        goBack: function () {
            this.$router.push(this.$route.query.fromPath)
        }
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
