window.initSkillsPage = function () {
    const skills = document.querySelectorAll('.skills-category');
    skills.forEach((skill, index) => {
        setTimeout(() => {
            skill.classList.add('slide-in');
        }, index * 300);
    });
};
