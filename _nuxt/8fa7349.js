(window.webpackJsonp=window.webpackJsonp||[]).push([[3],{436:function(t,e,o){var content=o(445);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,o(22).default)("353da41a",content,!0,{sourceMap:!1})},444:function(t,e,o){"use strict";o(436)},445:function(t,e,o){var d=o(21)(!1);d.push([t.i,".step-container[data-v-a2d947aa]{display:flex;flex-direction:column;align-items:center;margin-bottom:50px;width:90%;max-width:100%;padding:0 5px}.step-container-1[data-v-a2d947aa]{order:2}.step-container-1 .avatar[data-v-a2d947aa]{font-size:22px}.step-container-2[data-v-a2d947aa]{order:1}.step-container-2 .avatar[data-v-a2d947aa]{font-size:20px}.step-container-3[data-v-a2d947aa]{order:3}.step-container-3 .avatar[data-v-a2d947aa]{font-size:18px}.step[data-v-a2d947aa]{font-size:20px;width:100%;display:flex;flex-direction:column;align-items:center;justify-content:flex-start;padding-top:10px;box-sizing:border-box;border-radius:5px 5px 0 0}.step .podium-title[data-v-a2d947aa]{font-size:28px;font-weight:700;margin:0}.step1[data-v-a2d947aa]{height:200px;background-color:#c91dc9}.step1 .podium-title[data-v-a2d947aa]{color:#4e0b4e}.step2[data-v-a2d947aa]{height:150px;background-color:#65d91c}.step2 .podium-title[data-v-a2d947aa]{color:#2d610c}.step3[data-v-a2d947aa]{height:100px;background-color:#ff9116}.step3 .podium-title[data-v-a2d947aa]{color:#6c3900}.avatar[data-v-a2d947aa]{margin-bottom:24px;color:#fff}",""]),t.exports=d},453:function(t,e,o){"use strict";o.r(e);var d=o(188),r=(o(36),o(34),{name:"PodiumStep",props:{step:{type:Number,required:!0},item:{type:Object,required:!0}},computed:{styleForStep:function(){return"step"+this.step}}}),n=(o(444),o(69)),component=Object(n.a)(r,(function(){var t=this,e=t._self._c;return t.step<4?e("div",{class:["step-container","step-container-"+t.step]},[e(d.a,{staticClass:"avatar",attrs:{color:"primary",size:124-10*t.step}},[t._v("\n        "+t._s(t.item.name)+"\n    ")]),t._v(" "),e("div",{class:[t.styleForStep,"step"]},[e("p",{staticClass:"podium-title"},[t._v(t._s(t.step))]),t._v(" "),e("p",{staticClass:"podium-score"},[t._v(t._s(t.item.score))])])],1):t._e()}),[],!1,null,"a2d947aa",null);e.default=component.exports}}]);