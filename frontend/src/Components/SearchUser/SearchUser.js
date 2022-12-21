import React, { useEffect, useState } from 'react'
import axios from 'axios'
import Config from '../Settings/Config'
import Unauthorized from '../Unauthorized/Unauthorized';
import './Search.css'
import Alert from 'react-bootstrap/Alert';
import Select from "react-select";

function SearchBar() {
    const [users,setUsers] = useState([]);
    const [skills,setSkills] = useState([]);
    const [result,setResult] = useState([]);
    const [error,setError] = useState(false);
    // const [skillname, setSkillname] = useState([]);
    // const [selectedOptions, setSelectedOptions] = useState("");
    // const [SkillId, setSkillId] = useState("");
    //const [Skills, setSkills] = useState([]);      //To fetch all the skills in the dropdown

    useEffect(()=>{
        //fetchSkills();
        axios.get(Config.api + 'Users')
        .then(res => {
            setUsers(res.data)
            //console.log(users)
        })
        .catch(err => console.log(err))
    },[users]) 

    const handlesearchChange = (e) => {
    setSkills(e.target.value);
    
  }
   
//   const handlesearchSubmit = (e) => {
//     e.preventDefault();
//     axios.get(Config.api + `SearchCandidate/Search/${skills}`)
//       .then(response => { setResult(response.data); console.log(response.data)})
//       .catch(error => console.log(error))
    
 // }
//   //search and select options
//   let optionslist = []
//     for (let i =0; i< skillname.length; i++){
//         optionslist.push({ value: skillname[i].skillId, label: skillname[i].skillName });
       
//     }
//     function handleSelect(data){
//       setSelectedOptions(data);
//       setSkillId(data.value);
//     }

    // To fetch the Skills in the dropdown 
//   function fetchSkills() {
//     axios.get(Config.api + 'Skills',skills,skillname)
//       .then(res => res.data)
//       .then(res => { setSkills(res);setSkillname(res) })
//       .catch(err => console.log(err))
    
//   }
    function Search(e){
        e.preventDefault();
        if((skills.trim().length) !== 0)
        {
            axios.get(Config.api + `SearchCandidate/${skills}`)
            .then(res => {
                setResult(res.data)
                console.log(res.data)
            })
            .catch(error => setError(true))
        }
    }

 
  return (
    <>
    {Config.isUserLoggedin ? 
        <>
        <div className="Search">
        <Alert key={'danger'} variant={'danger'} style={{visibility: error ? 'visible' : 'hidden'}}>
              Not Found...
        </Alert>
        <div className='m-5'>
        <form className="d-flex" role="search">
            <input className="form-control me-2" type="search" placeholder="Search" onChange={handlesearchChange} />
            <button className="search-btn" type="submit" onClick={Search}>Search</button>
        </form>
        <hr/>
        {/* <Select
            className="select"
                      options={optionslist}
                      placeholder="Select skill"
                      value={selectedOptions}
                      onChange={handleSelect}
                      isSearchable={true}
                      maxMenuHeight={150}
        /> */}
        </div>
        <div>
        {result.map( r => (
        <div className="card mb-2" key={r.skillSetId}>
            <div className='card-body'>
                <div className='row'>
                    <div className='col-5'>
                        <p className="user-body"><b>{r.user.firstName +" "+ r.user.lastName}</b></p>
                        <p className="user-body">
                        <a href={"mailto:" + r.user.corpMail}><i className="add-role fa fa-envelope" aria-hidden="true"></i></a>
                        &nbsp;: {r.user.corpMail}
                        </p>
                        <p className="user-body">
                            <i className="fa fa-map-marker add-role" aria-hidden="true"></i>
                            &nbsp;: {r.user.location}
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <i class="fa fa-star text-warning" aria-hidden="true"></i>
                            &nbsp;: {r.user.grade}
                        </p>
                    </div>
                    <div className='col-2'>
                        {/* <p><i className="fa fa-user" aria-hidden="true"></i> : {r.user.roles.roleName}</p> */}
                        <p><i class="fa fa-cogs" aria-hidden="true"></i> : {r.skill.skillName}</p>
                    </div>
                    <div className='col-5 d-flex justify-content-end'>
                        <div className=''>
                        <button className="btn btn-secondary me-2"> View </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        ))}
        </div>
        </div>
        </> : 
        <>
            <Unauthorized/>
        </>
    }
    </>
  )
}

export default SearchBar