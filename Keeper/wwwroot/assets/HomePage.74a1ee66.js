import{_ as i,o as u,c as m,K as v,q as f,b as e,d as n,F as c,r as K,f as r,k,P as y,l as s,h as g,j as p}from"./index.19656839.js";const h={setup(){async function t(){try{await k.getAllKeeps()}catch(a){y.error(a)}}return u(()=>{t()}),{keeps:m(()=>g.keeps)}},components:{KeepCard:v,ActiveKeepModal:f}},A={class:"container"},x={class:"masonry-with-columns my-2"};function C(t,a,M,d,P,B){const _=p("KeepCard"),l=p("ActiveKeepModal");return s(),e(c,null,[n("div",A,[n("div",x,[(s(!0),e(c,null,K(d.keeps,o=>(s(),e("div",{key:o.id,class:"transaction"},[r(_,{keep:o},null,8,["keep"])]))),128))])]),r(l,{id:"activeKeep"})],64)}const w=i(h,[["render",C],["__scopeId","data-v-afd87d2c"]]);export{w as default};
