import{_ as x,y as K,z as V,w,c as u,P as d,B as m,K as I,q as k,A,b as o,d as t,t as l,e as r,F as p,r as S,f as h,l as c,h as _,p as C,m as B,j as y,C as P}from"./index.19656839.js";const j={setup(){const s=K(),n=V();async function v(){try{const a=s.params.vaultId;await m.getVaultById(a)}catch(a){d.error(a),n.push({name:"Home"})}}async function e(){try{const a=s.params.vaultId;await P.getVaultKeeps(a)}catch(a){d.error(a)}}return w(()=>{s.params.vaultId,v(),e()}),{vault:u(()=>_.vault),account:u(()=>_.account),vaultKeeps:u(()=>_.vaultKeeps),async deleteVault(){try{await d.confirm("Are you sure you want to remove your vault?","This action cannot be undone","Yes, I'm sure","warning")&&(await m.deleteVault(s.params.vaultId),d.toast("Vault has been deleted","success","center"),n.push({name:"Account"}))}catch(a){d.error(a,"[delete vault]")}}}},components:{KeepCard:I,ActiveKeepModal:k,ActiveVaultKeep:A}},f=s=>(C("data-v-dcb1bd17"),s=s(),B(),s),N={key:0,class:"container"},z={class:"row justify-content-center mt-4"},E={class:"col-md-8"},F={class:"card"},R=["src","alt"],q={class:"card-img-overlay d-flex align-items-end"},D={class:"d-flex flex-column align-items-center justify-content-center w-100 text-light"},H={class:"card-title text-center font"},L={key:0,class:"card-text"},M={key:1,class:"card-text"},T={key:0,class:"text-end me-2"},Y=f(()=>t("i",{class:"mdi mdi-lock text-light fs-3"},null,-1)),G=[Y],J={class:"col-md-8 text-center"},O={key:0,class:"dropstart d-flex justify-content-end"},Q=f(()=>t("i",{class:"mdi mdi-dots-horizontal btn-secondary fs-4",type:"button","data-bs-toggle":"dropdown","aria-expanded":"false",title:"See more"},null,-1)),U={class:"dropdown-menu mt-2 bg-success border border-1 border-dark"},W={key:1,class:"mt-3"},X={class:"bg-success rounded py-1 px-2"},Z={class:"row"},$={class:"masonry-with-columns"};function ee(s,n,v,e,a,te){const g=y("KeepCard"),b=y("ActiveVaultKeep");return c(),o(p,null,[e.vault?(c(),o("div",N,[t("section",z,[t("div",E,[t("div",F,[t("img",{class:"card-img",src:e.vault.img,alt:e.vault.name},null,8,R),t("div",q,[t("div",D,[t("h3",H,l(e.vault.name),1),e.account.id==e.vault.creatorId?(c(),o("p",L,"by "+l(e.account.name),1)):(c(),o("p",M,"by "+l(e.vault.creator.name),1))]),e.vault.isPrivate?(c(),o("div",T,G)):r("",!0)])])]),t("div",J,[e.vault.creatorId==e.account.id?(c(),o("div",O,[Q,t("ul",U,[t("li",{onClick:n[0]||(n[0]=i=>e.deleteVault()),class:"dropdown-item text-bold"},"delete vault")])])):r("",!0),e.vaultKeeps.length>0?(c(),o("h6",W,[t("span",X,l(e.vaultKeeps.length)+" Keeps ",1)])):r("",!0)])]),t("section",Z,[t("div",$,[(c(!0),o(p,null,S(e.vaultKeeps,i=>(c(),o("div",{key:i.id,class:"transaction"},[h(g,{keep:i},null,8,["keep"])]))),128))])])])):r("",!0),h(b,{id:"activeVaultKeep"})],64)}const se=x(j,[["render",ee],["__scopeId","data-v-dcb1bd17"]]);export{se as default};
